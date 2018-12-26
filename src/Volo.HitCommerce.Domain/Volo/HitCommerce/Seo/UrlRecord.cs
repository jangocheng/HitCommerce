using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Volo.HitCommerce.Seo
{
    public class UrlRecord : AggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Name { get; protected set; }
        
        [NotNull]
        public virtual string Slug { get; protected set; }

        public virtual Guid EntityId { get; protected set; }
        
        public virtual bool IsActive { get; set; }

        protected UrlRecord()
        {
        }

        public UrlRecord(Guid id, Guid entityId, [NotNull] string name, [NotNull] string slug)
        {
            Id = id;
            Slug = Check.NotNullOrWhiteSpace(slug, nameof(slug));
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            EntityId = entityId;
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