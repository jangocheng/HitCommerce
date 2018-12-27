using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Abstractions
{
    public abstract class Content : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        [StringLength(AbstractionConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        [NotNull]
        [StringLength(AbstractionConsts.MaxSlugLength)]
        public virtual string Slug { get; set; }

        public virtual string MetaTitle { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }

        public virtual bool IsPublished { get; protected set; }

        public virtual DateTimeOffset? PublishedOn { get; protected set; }

        protected virtual void Publish()
        {
            IsPublished = true;
            PublishedOn = DateTimeOffset.Now;
        }

        protected virtual void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            MetaTitle = Check.NotNullOrWhiteSpace(metaTitle, nameof(metaTitle));
            MetaKeywords = Check.NotNullOrWhiteSpace(metaKeywords, nameof(metaKeywords));
            MetaDescription = Check.NotNullOrWhiteSpace(metaDescription, nameof(metaDescription));
        }
    }
}
