using System;

namespace MediaLogue.Domain.Model
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Unique identifier used by TVDB.
        /// </summary>
        public int Id { get; private set; }

        public bool Equals(Entity other)
        {
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