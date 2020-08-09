using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NerdStore.Core.DomainObjects
{
    public abstract class Entity: IEquatable<Entity>
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals([AllowNull] Entity other)
        {
            return Id == other.Id;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
