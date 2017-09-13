using System.Collections.Generic;
using KelloData;
using KelloRepository.Contexts;

namespace KelloRepository
{
    public class KelloInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<KelloContext>
    {
        protected override void Seed(KelloContext context)
        {
            List<Board> boards = new List<Board>();
            boards.ForEach(board => context.Boards.Add(board));
            context.SaveChanges();


            List<KelloList> lists = new List<KelloList>();
            lists.ForEach(list => context.Lists.Add(list));
            context.SaveChanges();
        }
    }
}