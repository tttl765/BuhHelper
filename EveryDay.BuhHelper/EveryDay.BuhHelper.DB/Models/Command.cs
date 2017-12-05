using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.BuhHelper.DB.Models
{
    public class Command : IEntity
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }
    }
}
