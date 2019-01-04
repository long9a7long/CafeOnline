using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CafeOnline.Models
{
    public class RegisterModels
    {
       
            [Key]
            [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập.")]
            [StringLength(50)]
            [Display(Name = "Tên đăng nhập")]
            public string UserID { get; set; }

            [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
            [StringLength(20,MinimumLength =6,ErrorMessage ="Độ dài mật khẩu ít nhất 6 ký tự ")]
            [Display(Name = "Mật khẩu")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Bạn chưa nhập mật khẩu xác nhận.")]
            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Bạn chưa nhập tên hiển thị.")]
            [StringLength(50)]
            [Display(Name = "Tên hiển thị")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Bạn chưa nhập địa chỉ.")]
            [StringLength(50)]
            [Display(Name = "Địa chỉ")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Bạn chưa nhập số điện thoại.")]
            [StringLength(50)]
            [Display(Name = "Số điện thoại")]
            public string Phone { get; set; }

        
            [StringLength(50)]
            [Display(Name = "Email")]
            public string Email { get; set; }
    }

}