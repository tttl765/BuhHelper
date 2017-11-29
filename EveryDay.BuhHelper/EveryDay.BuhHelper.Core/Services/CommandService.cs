using EveryDay.BuhHelper.Console.Commands;
using EveryDay.BuhHelper.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.BuhHelper.Console.Services
{
    public class CommandService : ICommandService
    {
        public ICommandResult ExecCommand(string name, string arg)
        {
            throw new NotImplementedException();
        }

        public List<ICommand> GetCommands()
        {
            var list = new List<ICommand>();

            list.Add(new KonturINNCommand());
            list.Add(new KonturKPPCommand());

            var type = 
            Assembly.LoadFrom

            return list;
        }
    }
}
