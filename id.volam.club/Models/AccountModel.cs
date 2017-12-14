using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace id.volam.club.Models
{
    public class AccountBaseModel
    {
        public virtual string cAccName { get; set; }

        public virtual string cPassWord { get; set; }

        public string GetPasswordHash()
        {
            return GetHash(cPassWord);
        }

        protected string GetHash(string pass)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString().ToUpper();
        }
    }
}