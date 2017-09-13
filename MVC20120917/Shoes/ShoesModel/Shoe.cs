using System;

namespace ShoesModel
{
    public class Shoe
    {
        public Shoe()
        {
            TimeAdded = DateTime.Now;
        }

        public int Id { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }

        public int Size { get; set; }

        public DateTime TimeAdded { get; set; }

        public string OwnerEmail { get; set; }
    }
}