using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace id.volam.club.Models
{
    public class LoginModel : AccountBaseModel
    {
        [Required(ErrorMessage = "Chưa nhập vào tên tài khoản!")]
        [StringLength(32, ErrorMessage = "Tài khoản từ 6 đến 32 ký tự!", MinimumLength = 6)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Tài khoản chỉ bao gồm chữ cái và số!")]
        public override string cAccName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập vào mật khẩu!")]
        [StringLength(32, ErrorMessage = "Mật khẩu từ 6 đến 32 ký tự!", MinimumLength = 6)]
        public override string cPassWord { get; set; }
    }
}