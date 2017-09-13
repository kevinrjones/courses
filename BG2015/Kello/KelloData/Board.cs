using System.Collections.Generic;

namespace KelloData
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<KelloList> Lists{ get; set; }
    }
}