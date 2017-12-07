using System;

namespace EveryDay.BuhHelper.DB.Models
{
    public class Command : IEntity
    {
        public virtual Guid Uid { get; set; }

        public virtual string Name { get; set; }
    }
}
