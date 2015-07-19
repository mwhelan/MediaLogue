using System;

namespace MediaLogue.Domain.Model
{
    public abstract class Entity : IEquatable<Entity>
    {
        /// <summary>
        /// Unique identifier used by TVDB.
        /// </summary>
        public int Id { get; set; }

        public bool Equals(Entity other)
        {
            if (other == null) return false; 
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}