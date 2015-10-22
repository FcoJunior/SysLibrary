using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SysLibrary.Entidades.DTO;

namespace SysLibrary.WebApi.Controllers
{
    public class AccountController : Controller
    {
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
        public async Task<ActionResult> Login(UsuarioDTO model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        var user = await UserManager.FindAsync(model.Email, model.Password);
            //        if (!user.EmailConfirmed)
            //        {
            //            TempData["AvisoEmail"] = "Usuário não confirmado, verifique seu e-mail.";
            //        }
            //        await SignInAsync(user, model.RememberMe);
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Login ou Senha incorretos.");
            return View(model);
        }
    }
}