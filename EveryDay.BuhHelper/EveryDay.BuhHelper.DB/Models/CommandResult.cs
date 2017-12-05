using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.BuhHelper.DB.Models
{
    public class CommandResult : IEntity
    {
        public Guid Uid { get; set; }

        public Command Command { get; set; }
        public Guid CommandUid { get; set; }

        public User Author { get; set; }
        public Guid AuthorUid { get; set; }

        public string Args { get; set; }

        public string Result { get; set; }

        public DateTime ExecDate { get; set; }

        public int Time { get; set; }

    }
}
