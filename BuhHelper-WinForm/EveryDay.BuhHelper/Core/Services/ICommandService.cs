﻿using EveryDay.BuhHelper.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.BuhHelper.Console.Services
{
    public interface ICommandService
    {
        /// <summary>
        /// Получить список доступных команд
        /// </summary>
        /// <returns>Список команд</returns>
        [Obsolete("Используйте метод GetCommands(string extName)", true)]
        List<ICommand> GetCommands();

        List<ICommand> GetCommands(string extName);

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="name">Команда</param>
        /// <param name="arg">Аргументы</param>
        /// <returns>Результат</returns>
        ICommandResult ExecCommand(string name, string arg);
    }
}
