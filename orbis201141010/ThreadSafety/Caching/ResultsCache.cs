using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;

namespace Caching
{
    public class MatchResult
    {
        public string FirstTeam { get; set; }
        public int FirstTeamScore { get; set; }

        public string SecondTeam { get; set; }
        public int SecondTeamScore { get; set; }

        public override string ToString()
        {
            return String.Format("{0} : {1} {2}:{3}", FirstTeam, FirstTeamScore, SecondTeam, SecondTeamScore);
        }
    }

    public abstract class ResultsCache
    {
        protected List<MatchResult> results = new List<MatchResult>();

        public abstract IEnumerable<MatchResult> GetResults(string country);
        public abstract void AddResult(MatchResult resultsToAdd);

    }

    class SimpleResultsCache : ResultsCache
    {

        public override IEnumerable<MatchResult> GetResults(string country)
        {
           
            return from result in results
                   where result.FirstTeam == country || result.SecondTeam == country
                   select result;
        }

        public override void AddResult(MatchResult result)
        {
            results.Add(result);
        }
    }

    class MonitorResultsCache : ResultsCache
    {
        object _lock = new object();


        public override IEnumerable<MatchResult> GetResults(string country)
        {
            lock (_lock)
            {
                return (from result in results
                    where result.FirstTeam == country || result.SecondTeam == country
                    select result).ToList();
            }
        }

        public override void AddResult(MatchResult result)
        {
            lock (_lock)
            {
                results.Add(result);
            }
        }
    }

    class RWResultsCache : ResultsCache
    {
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();


        public override IEnumerable<MatchResult> GetResults(string country)
        {
            _lock.EnterReadLock();
            
            var res = (from result in results
                        where result.FirstTeam == country || result.SecondTeam == country
                        select result).ToList();
            _lock.ExitReadLock();
            return res;

        }

        public override void AddResult(MatchResult result)
        {
            _lock.EnterWriteLock();
            {
                results.Add(result);
            }
            _lock.ExitWriteLock();
        }
    }

    class NoLockResultsCache : SimpleResultsCache
    {
        public override void AddResult(MatchResult result)
        {
            var res = new List<MatchResult>(results);
            res.Add(result);
            results = res;
        }
    }
}
