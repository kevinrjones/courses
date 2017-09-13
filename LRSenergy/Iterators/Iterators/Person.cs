using System;
using System.Collections.Generic;

namespace Iterators
{
    public class Person
    {
        readonly List<Possesion> _possesions = new List<Possesion>();

        public void Add(Possesion book)
        {
            _possesions.Add(book);
        }

        public IEnumerable<Possesion> Find(Predicate<Possesion> filter)
        {
            foreach (var possesion in _possesions)
            {
                if (filter == null || filter(possesion))
                {
                    yield return possesion;
                }
            }
        }
    }
}