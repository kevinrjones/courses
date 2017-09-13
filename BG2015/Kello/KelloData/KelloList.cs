using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelloData
{
    public class KelloList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Card> Cards{ get; set; }
    }
}
