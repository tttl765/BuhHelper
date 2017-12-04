using EveryDay.BuhHelper.Console.Models;
using System.Collections.Generic;

namespace Web.Models
{
    public class CommandViewModel
    {
        /// <summary>
        /// Список доступных команд
        /// </summary>
        public IList<ICommand> Commands { get; set; }

        /// <summary>
        /// Результат выполнения команды
        /// </summary>
        public ICommandResult Result { get; set; }
    }
}