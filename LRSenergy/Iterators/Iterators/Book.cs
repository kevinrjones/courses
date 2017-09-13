using System.Security.Policy;

namespace Iterators
{
    public abstract class Possesion
    {
        public abstract decimal Price { get; set; }
        public string Title { get; set; }
        public abstract void Accept(PossesionVisitor visitor);
    }

    public class Book : Possesion
    {
        public override decimal Price { get; set; }
        public string Author { get; set; }
        public override void Accept(PossesionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class CompactDisk : Possesion
    {
        private decimal _price;

        public override decimal Price
        {
            get { return _price * 1.02m; }
            set { _price = value; }
        }

        public string Title { get; set; }
        public override void Accept(PossesionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class DigitalVersatileDisk : Possesion
    {
        private decimal _price;

        public override decimal Price
        {
            get { return _price * 1.1m; }
            set { _price = value; }
        }

        public string Title { get; set; }
        public override void Accept(PossesionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public abstract class PossesionVisitor
    {
        public abstract void Visit(Possesion book);
        public abstract void VisitBook(Book book);
        public abstract void VisitCD(CompactDisk cd);
        public abstract void VisitDVD(DigitalVersatileDisk dvd);
    }

    public class PriceVisitor : PossesionVisitor
    {
        public decimal Price { get; set; }
        public override void Visit(Possesion possesion)
        {
            Price += possesion.Price;
        }

        public override void VisitBook(Book book)
        {
            Price += book.Price;
        }

        public override void VisitCD(CompactDisk cd)
        {
            Price += cd.Price;
        }

        public override void VisitDVD(DigitalVersatileDisk dvd)
        {
            Price += dvd.Price;
        }
    }
}