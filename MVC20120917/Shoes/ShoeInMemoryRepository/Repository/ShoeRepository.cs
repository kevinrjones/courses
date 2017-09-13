using System.Collections.Generic;
using System.Linq;
using ShoeInMemoryRepository.Interfaces;
using ShoesModel;

namespace ShoeInMemoryRepository.Repository
{
    public class ShoeRepository : IShoeRepository
    {
        static readonly IList<Shoe> Shoes = new List<Shoe>
                                {
                                    new Shoe{Color = "Red", Type = "Desert", Size = 45, OwnerEmail = "fred@foo.com"},
                                    new Shoe{Color = "Green", Type = "Court", Size = 37, OwnerEmail = "alice@foo.com"},
                                    new Shoe{Color = "Blue", Type = "Chelsea Boot", Size = 45, OwnerEmail = "bob@foo.com"},
                                    new Shoe{Color = "Black", Type = "Formal", Size = 38, OwnerEmail = "clare@foo.com"},
                                };
        public void Dispose()
        {
        }

        public IQueryable<Shoe> Entities
        {
            get { return Shoes.AsQueryable(); }
        }
  
        public Shoe New()
        {
            return new Shoe();
        }

        public void Update(Shoe entity)
        {
            var shoe = (from s in Shoes
                        where s.Id == entity.Id
                        select s).First();

            if (shoe != null)
            {
                shoe.Color = entity.Color;
                shoe.Type = entity.Type;
                shoe.Size = entity.Size;
                shoe.OwnerEmail = entity.OwnerEmail;
            }
        }

        public void Create(Shoe entity)
        {
            Shoes.Add(entity);
        }

        public void Delete(Shoe entity)
        {
            var shoe = (from s in Shoes
                        where s.Id == entity.Id
                        select s).First();

            Shoes.Remove(shoe);
        }

        public Shoe GetShoe(int id)
        {
            return (from s in Shoes
                        where s.Id == id
                        select s).First();
        }
    }
}
