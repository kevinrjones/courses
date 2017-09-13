using System;
using System.Linq;
using KelloData;
using KelloRepository.Contexts;
using KelloRepository.Interfaces;
using Repository;

namespace KelloRepository.Repositories
{
    public class BoardRepository : BaseEfRepository<Board>, IBoardRepository
    {
        public BoardRepository(KelloContext dbContext)
            : base(dbContext)
        {
        }

        public Board GetBoard(string title)
        {
            return (from b in Entities
                    where b.Title == title
                    select b).FirstOrDefault();
        }
    }
}