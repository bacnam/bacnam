using id.volam.club.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace id.volam.club.ApiController
{
    public class AccountApiController
    {
        public static string Login(string cAccName, string cPassWord)
        {
            string message = string.Empty;
            try
            {
                AccountEntities accountEntities = new AccountEntities();
                var account = accountEntities.Account_Info.Where(vm => vm.cAccName == cAccName && vm.cPassWord == cPassWord);

                if (account.Count() > 0)
                {
                    //var info = account.First<Account_Info>();
                }
                else
                {
                    message = "Tài khoản hoặc mật khẩu không chính xác!";
                }
            }
            catch (Exception)
            {
                message = "Đăng nhập thất bại";
            }
            return message;
        }

        public static string Register(Account_Info account_Info)
        {
            string message = string.Empty;
            try
            {
                AccountEntities accountEntities = new AccountEntities();
                var account = accountEntities.Account_Info.Where(vm => vm.cAccName == account_Info.cAccName || vm.cEmail == account_Info.cEmail);

                if (account.Count() > 0)
                {
                    message = "Tài khoản hoặc Email đã tồn tại!";
                }
                else
                {
                    accountEntities.Account_Info.Add(account_Info);
                    accountEntities.Account_Habitus.Add(new Account_Habitus()
                    {
                        cAccName = account_Info.cAccName,
                        dEndDate = new DateTime(2050, 1, 1),
                        iLeftSecond = 0,
                        iUseSecond = 0
                    });
                    accountEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                message = "Đăng ký tài khoản thất bại";
            }
            return message;
        }

        public static string ChangePassword(string cAccName, string cOldPassWord, string cPassWord)
        {
            string message = string.Empty;
            try
            {
                AccountEntities accountEntities = new AccountEntities();
                var accounts = accountEntities.Account_Info.Where(vm => vm.cAccName == cAccName && vm.cPassWord == cOldPassWord);

                if (accounts.Count() <= 0)
                {
                    message = "Tài khoản hoặc mật khẩu không chính xác!";
                }
                else
                {
                    accounts.FirstOrDefault<Account_Info>().cPassWord = cPassWord;
                    accountEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                message = "Đổi mật khẩu thất bại";
            }
            return message;
        }

        public static string ChangeSecPassword(string cAccName, string cOldSecPassWord, string cSecPassWord)
        {
            string message = string.Empty;
            try
            {
                AccountEntities accountEntities = new AccountEntities();
                var accounts = accountEntities.Account_Info.Where(vm => vm.cAccName == cAccName && vm.cSecPassWord == cOldSecPassWord);

                if (accounts.Count() <= 0)
                {
                    message = "Tài khoản hoặc mật khẩu không chính xác!";
                }
                else
                {
                    accounts.FirstOrDefault<Account_Info>().cSecPassWord = cSecPassWord;
                    accountEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                message = "Đổi mật khẩu thất bại";
            }
            return message;
        }

        public static string ResetPassword(string cAccName, string cSecPassWord, string cPassWord)
        {
            string message = string.Empty;
            try
            {
                AccountEntities accountEntities = new AccountEntities();
                var accounts = accountEntities.Account_Info.Where(vm => vm.cAccName == cAccName && vm.cSecPassWord == cSecPassWord);

                if (accounts.Count() <= 0)
                {
                    message = "Tài khoản hoặc mật khẩu không chính xác!";
                }
                else
                {
                    accounts.FirstOrDefault<Account_Info>().cPassWord = cPassWord;
                    accountEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                message = "Đổi mật khẩu thất bại";
            }
            return message;
        }
    }
}