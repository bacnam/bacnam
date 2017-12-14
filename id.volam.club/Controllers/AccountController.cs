using id.volam.club.ApiController;
using id.volam.club.Database;
using id.volam.club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace id.volam.club.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý tài khoản";
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Đăng nhập";
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel param)
        {
            string message = string.Empty;

            try
            {
                if (!ModelState.IsValid)
                    return View();

                message = AccountApiController.Login(param.cAccName, param.GetPasswordHash());
                if (!string.IsNullOrEmpty(message))
                {
                    ModelState.AddModelError("Error", message);
                }
                else
                {
                    ModelState.AddModelError("Success", "Đăng nhập thành công!");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);

                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Title = "Đăng ký tài khoản";
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel param)
        {
            ViewBag.Title = "Đăng ký tài khoản";
            try
            {
                if (!ModelState.IsValid)
                    return View();

                Account_Info account_Info = new Account_Info()
                {
                    cAccName = param.cAccName,
                    cPassWord = param.GetPasswordHash(),
                    cSecPassWord = param.GetSecPasswordHash(),
                    cEmail = param.cEmail,
                    cPhone = param.cPhone,
                    cFullName = UnicodeToISO(param.cFullName),
                    nExtPoint2 = 1000,
                    iServiceFlag = 1,
                };
                string message = AccountApiController.Register(account_Info);
                if (!string.IsNullOrEmpty(message))
                {
                    ModelState.AddModelError("Error", message);
                }
                else
                {
                    ModelState.AddModelError("Success", "Đăng ký tài khoản thành công");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);

                return View();
            }
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            ViewBag.Title = "Đổi mật khẩu cấp 1";
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel param)
        {
            ViewBag.Title = "Đổi mật khẩu cấp 1";
            try
            {
                if (!ModelState.IsValid)
                    return View();

                string message = AccountApiController.ChangePassword(param.cAccName, param.GetOldPasswordHash(), param.GetPasswordHash());
                if (!string.IsNullOrEmpty(message))
                {
                    ModelState.AddModelError("Error", message);
                }
                else
                {
                    ModelState.AddModelError("Success", "Đổi mật khẩu thành công");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);

                return View();
            }
        }

        [HttpGet]
        public ActionResult ChangeSecPassword()
        {
            ViewBag.Title = "Đổi mật khẩu cấp 2";
            return View();
        }

        [HttpPost]
        public ActionResult ChangeSecPassword(ChangeSecPasswordModel param)
        {
            ViewBag.Title = "Đổi mật khẩu cấp 2";
            try
            {
                if (!ModelState.IsValid)
                    return View();

                string message = AccountApiController.ChangeSecPassword(param.cAccName, param.GetOldSecPasswordHash(), param.GetSecPasswordHash());
                if (!string.IsNullOrEmpty(message))
                {
                    ModelState.AddModelError("Error", message);
                }
                else
                {
                    ModelState.AddModelError("Success", "Đổi mật khẩu thành công!");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);

                return View();
            }
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            ViewBag.Title = "Đổi mật khẩu cấp 1";
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel param)
        {
            ViewBag.Title = "Đổi mật khẩu cấp 1";
            try
            {
                if (!ModelState.IsValid)
                    return View();

                string message = AccountApiController.ResetPassword(param.cAccName, param.GetSecPasswordHash(), param.GetPasswordHash());
                if (!string.IsNullOrEmpty(message))
                {
                    ModelState.AddModelError("Error", message);
                }
                else
                {
                    ModelState.AddModelError("Success", "Đổi mật khẩu thành công!");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);

                return View();
            }
        }

        private string UnicodeToISO(string srcString)
        {
            Encoding iso = Encoding.GetEncoding("GB2312");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(srcString);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            return iso.GetString(isoBytes);
        }
    }
}