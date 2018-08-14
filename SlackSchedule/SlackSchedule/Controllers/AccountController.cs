
using HPBFramework.Logger;
using SlackSchedule.Models;
using SlackSchedule.Services.IServices;
using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SlackSchedule.Controllers
{
    [AllowAnonymous]
    public class AccountController : ControllerExtention
    {
        public AccountController(ILoggingService loggingService, ICommonService commonService) 
            : base(loggingService, commonService)
        {
            _loggingService = loggingService;
            _commonService = commonService;
        }

        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Member member)
        {
            member = new Member()
            {
                Name = "AAAA",
                Active = true
            };
            CreateLoginAuth(member);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        private void CreateLoginAuth(Member member)
        {
            Session["LoginUser"] = member.Name;
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, member.Name),
                new Claim(ClaimTypes.Role, member.Active ? "Admin" : "Member")
            },
            "ApplicationCookie");

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignIn(identity);

        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }
    }
}
