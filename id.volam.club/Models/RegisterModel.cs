using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace id.volam.club.Models
{
    public class RegisterModel : AccountBaseModel
    {
        [Required(ErrorMessage = "Chưa nhập vào tên tài khoản!")]
        [StringLength(32, ErrorMessage = "Tài khoản từ 6 đến 32 ký tự!", MinimumLength = 6)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Tài khoản chỉ bao gồm chữ cái và số!")]
        public override string cAccName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Chưa nhập vào mật khẩu!")]
        [StringLength(32, ErrorMessage = "Mật khẩu từ 6 đến 32 ký tự!", MinimumLength = 6)]
        public override string cPassWord { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập vào mật khẩu!")]
        [StringLength(32, ErrorMessage = "Mật khẩu từ 6 đến 32 ký tự!", MinimumLength = 6)]
        [Compare("cPassWord", ErrorMessage = "Nhập lại mật khẩu không chính xác!")]
        public string cRePassWord { get; set; }

        [Required(ErrorMessage = "Chưa nhập vào Địa chỉ Email!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Địa chỉ email không chính xác!")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không chính xác!")]
        [StringLength(120, ErrorMessage = "Độ dài Email tối đa 120 ký tự!")]
        public string cEmail { get; set; }

        [Required(ErrorMessage = "Chưa nhập vào Họ và Tên!")]
        [StringLength(60, ErrorMessage = "Độ dài Họ và Tên tối đa 60 ký tự!")]
        public string cFullName { get; set; }

        [Required(ErrorMessage = "Chưa nhập vào Số điện thoại!")]
        [StringLength(20, ErrorMessage = "Độ dài Số điện thoại từ 10 đến 20 ký tự!", MinimumLength = 10)]
        public string cPhone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập vào mật khẩu!")]
        [StringLength(32, ErrorMessage = "Mật khẩu từ 6 đến 32 ký tự!", MinimumLength = 6)]
        public string cSecPassWord { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập vào mật khẩu!")]
        [StringLength(32, ErrorMessage = "Mật khẩu từ 6 đến 32 ký tự!", MinimumLength = 6)]
        [Compare("cSecPassWord", ErrorMessage = "Nhập lại mật khẩu không chính xác!")]
        public string cReSecPassWord { get; set; }

        public string GetSecPasswordHash()
        {
            return GetHash(cSecPassWord);
        }
    }
}