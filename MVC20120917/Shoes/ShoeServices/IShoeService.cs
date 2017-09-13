using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoesModel;

namespace ShoeServices
{
    public interface IShoeService
    {
        IEnumerable<Shoe> GetShoes();
        void Create(Shoe shoe);
    }
}
