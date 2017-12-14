using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace id.volam.club.Models
{
    public class ChangeSecPasswordModel : AccountBaseModel
    {
        public ChangeSecPasswordModel()
        {
        }

        [Required(ErrorMessage = "Chưa nhập vào tên tài khoản!")]
        [StringLength(32, ErrorMessage = "Tài khoản từ 6 đến 32 ký tự!", MinimumLength = 6)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Tài khoản chỉ bao gồm chữ cái và số!")]
        public override string cAccName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập vào mật khẩu!")]
        [StringLength(32, ErrorMessage = "Mật khẩu từ 6 đến 32 ký tự!", MinimumLength = 6)]
        public string cOldSecPassWord { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập vào mật khẩu!")]
        [StringLength(32, ErrorMessage = "Mật khẩu từ 6 đến 32 ký tự!", MinimumLength = 6)]
        public string cSecPassWord { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập vào mật khẩu!")]
        [StringLength(32, ErrorMessage = "Mật khẩu từ 6 đến 32 ký tự!", MinimumLength = 6)]
        [Compare("cSecPassWord", ErrorMessage = "Nhập lại mật khẩu không chính xác!")]
        public string cReSecPassWord { get; set; }

        public string GetOldSecPasswordHash()
        {
            return GetHash(cOldSecPassWord);
        }

        public string GetSecPasswordHash()
        {
            return GetHash(cSecPassWord);
        }
    }
}