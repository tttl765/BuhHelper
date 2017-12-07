using System;

namespace EveryDay.BuhHelper.DB.Models
{
    public class User : IEntity
    {
        public virtual Guid Uid { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string FIO { get; set; }

    }
}
