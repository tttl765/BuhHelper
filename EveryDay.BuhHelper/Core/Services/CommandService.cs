using EveryDay.BuhHelper.Console.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EveryDay.BuhHelper.Console.Services
{
    public class CommandService : ICommandService
    {
        public ICommandResult ExecCommand(string name, string arg)
        {
            throw new NotImplementedException();
        }

        [Obsolete("Используйте метод GetCommands(string extName)", true)]
        public List<ICommand> GetCommands()
        {
            return GetCommands("Ext");
        }

        public List<ICommand> GetCommands(string extName)
        {
            var list = new List<ICommand>();

            var currentAssembly = Assembly.GetAssembly(typeof(ICommand));

            list.AddRange(GetCommands(currentAssembly));

            var extsDirectory = Path.Combine(Environment.CurrentDirectory, extName);

            if (Directory.Exists(extsDirectory))
            {
                var exts = Directory.GetFiles(extsDirectory, "*.dll");

                foreach (var dllName in exts)
                {
                    var assembly = Assembly.LoadFrom(dllName);
                    list.AddRange(GetCommands(assembly));
                }
            }        

            return list;
        }

        private IEnumerable<ICommand> GetCommands(Assembly assembly)
        {
            var list = new List<ICommand>();

            // загрузка всех классов из этой dll
            var classes = assembly.GetTypes();

            var typeCommand = typeof(ICommand);

            // перебрать все классы
            foreach (var item in classes)
            {
                if (item.IsAbstract || item.IsInterface)
                    continue;

                // выбрать те, которые реализую интерфес ICommand
                // получаем все интерфейсы
                var inters = item.GetInterfaces();

                // перебираем их
                //находим с нужным именем
                var comInterface = inters.FirstOrDefault(i => i == typeCommand);

                if (comInterface != null)
                {
                    // создать экземпляр класса
                    var instCommand = Activator.CreateInstance(item) as ICommand;

                    // добавить его в список
                    list.Add(instCommand);
                }

            }

            return list;
        }
    }
}
