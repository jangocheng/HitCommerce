using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Volo.HitCommerce.BaseEntities
{
    public class BaseEntity : AggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Name { get; protected set; }
        
        [NotNull]
        public virtual string Slug { get; protected set; }

        public virtual Guid EntityId { get; protected set; }

        public virtual Guid BaseEntityTypeId { get; protected set; }

        protected BaseEntity()
        {
        }

        public BaseEntity(Guid id, [NotNull] string name, [NotNull] string slug, Guid entityId,
            Guid baseEntityTypeId)
        {
            Id = id;
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            EntityId = entityId;
            BaseEntityTypeId = baseEntityTypeId;
        }

        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public virtual void SetSlug([NotNull] string slug)
        {
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
        }
    }
}