using EveryDay.BuhHelper.Console.Models;
using System;

namespace EveryDay.BuhHelper.Console.Commands
{
    public class DayInMonth : ICommand
    {
        public string Name => "dim";

        public ICommandResult Exec(string arg)
        {
            var result = new CommandResult();

            var now = DateTime.Now;
            
            result.Result = $"Сегодня такой день - {now.ToShortDateString()}";

            result.Success = true;

            return result;
        }
    }
}
