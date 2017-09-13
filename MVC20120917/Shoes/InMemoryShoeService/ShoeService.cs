using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoeInMemoryRepository.Interfaces;
using ShoeServices;
using ShoesModel;

namespace InMemoryShoeServices
{
    public class ShoeService : IShoeService
    {
        readonly IShoeRepository _repository;

        public ShoeService(IShoeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Shoe> GetShoes()
        {
            return _repository.Entities.ToList();
        }

        public void Create(Shoe shoe)
        {
            _repository.Create(shoe);
        }
    }
}
