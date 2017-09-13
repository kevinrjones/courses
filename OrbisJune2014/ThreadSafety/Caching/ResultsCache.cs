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

    class MonitorResultsCache : SimpleResultsCache
    {
        object guard = new object();
        public override void AddResult(MatchResult result)
        {
            lock (guard)
            {
                base.AddResult(result);
            }
        }

        public override IEnumerable<MatchResult> GetResults(string country)
        {
            lock (guard)
            {
                return from result in results.ToList()
                       where result.FirstTeam == country || result.SecondTeam == country
                       select result;
            }
        }
    }

    class RWResultsCache : ResultsCache
    {   
        ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        public override IEnumerable<MatchResult> GetResults(string country)
        {
            rwLock.EnterReadLock();
            try
            {
                return from result in results.ToList()
                    where result.FirstTeam == country || result.SecondTeam == country
                    select result;
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }

        public override void AddResult(MatchResult result)
        {
            rwLock.EnterWriteLock();
            try
            {
                results.Add(result);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
    }

    class NoLockResultsCache : SimpleResultsCache
    {
        object guard = new object();
        public override void AddResult(MatchResult result)
        {
            lock (guard)
            {
                var local = new List<MatchResult>(results);
                local.Add(result);
                results = local;
            }
        }
    }
}
