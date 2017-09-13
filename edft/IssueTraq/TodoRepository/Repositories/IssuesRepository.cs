using Entities;
using IssueRepository.Interfaces;

namespace IssueRepository.Repositories
{
    public class IssueRepository : BaseEfRepository<Issue>, IIssueRepository
    {
        public IssueRepository() 
            : base(new IssueTraqEntities())
        {
        }

    }
}