using System;

namespace EveryDay.BuhHelper.DB.Models
{
    public class User : IEntity
    {
        public Guid Uid { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string FIO { get; set; }

    }
}
