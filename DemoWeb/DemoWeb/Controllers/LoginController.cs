using Demo.Data.Models;
using Demo.Data.ViewModels;
using Demo.Service;
using Demo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoWeb.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;

        public LoginController()
        {
            this.userService = new UserService();
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if(Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var loginData = new User() 
            { 
                Account = loginViewModel.Account,
                Password = loginViewModel.Password
            };
            if (this.userService.CheckPassword(loginData))
            {
                this.WriteAuthenticationTicket(loginData.Account);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "登入失敗");
                loginViewModel.Password = "";
                return View(loginViewModel);
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();

            return RedirectToAction("Login");
        }


        /// <summary>
        /// 寫入登入資訊
        /// </summary>
        /// <param name="Name"></param>
        private void WriteAuthenticationTicket(string Account)
        {
            Session.RemoveAll(); //Session 清空
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            version: 1,
            name: Account,                                     //你想要存放在 User.Identy.Name 的值，通常是使用者帳號
            issueDate: DateTime.UtcNow,
            expiration: DateTime.UtcNow.AddMinutes(30),         //過期時間
            isPersistent: false,                                //將管理者登入的 Cookie 設定成 Session Cookie
            userData: "",                                 //可以存放需要的使用者資訊
            cookiePath: FormsAuthentication.FormsCookiePath);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }
    }
}