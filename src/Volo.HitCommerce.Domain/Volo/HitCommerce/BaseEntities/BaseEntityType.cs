using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Volo.HitCommerce.BaseEntities
{
    public class BaseEntityType : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual string AreaName { get; protected set; }

        public virtual string RoutingController { get; protected set; }

        public virtual string RoutingAction { get; protected set; }
        
        public virtual bool IsMenuable { get; set; }

        protected BaseEntityType()
        {
        }

        public BaseEntityType(
            Guid id,
            [NotNull] string name)
        {
            Id = id;
            Name = name;
        }

        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public virtual void SetRouter(
            [NotNull] string routingController,
            [NotNull] string routingAction,
            [NotNull] string areaName)
        {
            RoutingController = Check.NotNullOrWhiteSpace(routingController, nameof(routingController));
            RoutingAction = Check.NotNullOrWhiteSpace(routingAction, nameof(routingAction));
            AreaName = Check.NotNullOrWhiteSpace(areaName, nameof(areaName));
        }
    }
}
