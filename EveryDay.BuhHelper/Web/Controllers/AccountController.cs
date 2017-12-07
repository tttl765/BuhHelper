using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Web.Models;
using EveryDay.BuhHelper.DB;
using EveryDay.BuhHelper.DB.Models;
using System.Web.Security;
using EveryDay.BuhHelper.NHibernate.Repositories;
using EveryDay.BuhHelper;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserRepository UserRepository;

        public AccountController()
        {
            UserRepository = new UserRepository();
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = UserRepository.Find(model.Email, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("Email", "Invalid login attempt.");
                return View(model);
            }
            // создаем куки
            FormsAuthentication.SetAuthCookie(model.Email, true);

            return RedirectToLocal(returnUrl);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User {
                    Login = model.Email,
                    Password = model.Password,
                    FIO = model.Email
                };

                if (user.Save())
                {
                    // todo: запомнить пользователя                    
                    FormsAuthentication.SetAuthCookie(model.Email, true);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Password", "Не удалось создать пользователя");
            }

            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}