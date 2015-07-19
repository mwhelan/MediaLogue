namespace MediaLogue.Domain.Model
{
    public class Banner : Entity
    {
        public string RemotePath { get; set; }

        public double? Rating { get; set; }

        public int? RatingCount { get; set; }
    }
}
