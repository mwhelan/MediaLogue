using System;

namespace MediaLogue.Core.Domain.Model
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
        public int Id { get; }

        public bool Equals(Entity other) => other?.Id == Id;

        public override bool Equals(object obj) => Equals(obj as Entity);

        public override int GetHashCode() => Id.GetHashCode();
    }
}