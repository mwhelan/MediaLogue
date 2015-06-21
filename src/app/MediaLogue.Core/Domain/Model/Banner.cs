using System;

namespace MediaLogue.Core.Domain.Model
{
    public class Banner : Entity
    {
        public Banner(int id)
            : base(id) { }

        public string RemotePath { get; set; }

        public Language? Language { get; set; }

        public double? Rating { get; set; }

        public int? RatingCount { get; set; }
    }
}
