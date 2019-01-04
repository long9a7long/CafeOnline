using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeOnline.Models
{
    public class LoginModel
    {
        [Key]
        [StringLength(50)]
        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập.")]
        [Display(Name = "Tên đăng nhập")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

    }
}