namespace MediaLogue.Domain.Model
{
    public class Banner : Entity
    {
        public Banner(int id)
            : base(id) { }

        public string RemotePath { get; set; }

        public double? Rating { get; set; }

        public int? RatingCount { get; set; }
    }
}
