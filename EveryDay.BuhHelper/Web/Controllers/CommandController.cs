using EveryDay.BuhHelper.Console.Services;
using EveryDay.BuhHelper.DB;
using EveryDay.BuhHelper.NHibernate.Repositories;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class CommandController : Controller
    {
        private ICommandService CommandService { get; set; }

        private ICommandRepository CommandRepository { get; set; }

        public CommandController()
        {
            CommandService = new CommandService();
            CommandRepository = new CommandRepository();
        }

        // GET: Command
        public ActionResult Index(string command, string args)
        {
            // получить список команд
            var Commands = CommandService.GetCommands("Ext");

            // передаем во вьюху
            var model = new CommandViewModel();
            model.Commands = Commands;

            var selectCommand = Commands.FirstOrDefault(c => c.Name == command);

            if(selectCommand != null)
            {
                model.Result = selectCommand.Exec(args);
            }

            ViewBag.Commands = CommandRepository.GetAll();

            return View(model);
        }

        //[HttpPost]
        public PartialViewResult Exec(string command, string args)
        {
            // получить список команд
            var Commands = CommandService.GetCommands("Ext");

            var selectCommand = Commands.FirstOrDefault(c => c.Name == command);

            if (selectCommand != null)
            {
                var result = selectCommand.Exec(args);

                return PartialView(result);
            }

            return PartialView();
        }
    }
}