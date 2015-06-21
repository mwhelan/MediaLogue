﻿namespace MediaLogue.Core.Domain.Model
{
    public class Actor : Entity
    {
        public Actor(int id) 
            : base(id) { }

        public string ImageRemotePath { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public int SortOrder { get; set; }
    }
}
