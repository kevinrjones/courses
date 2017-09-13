namespace KelloData
{
    public class Card
    {
        public int Id { get; set; }
        public CardType Type { get; set; }
        public string Title { get; set; }
        public virtual int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}