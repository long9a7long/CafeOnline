namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Bills = new HashSet<Bill>();
        }

        [StringLength(50)]
        
        [Display(Name ="Tên đăng nhập")]
        public string UserID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên hiển thị")]
        public string FullName { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public int GrantID { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool isActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual Grant Grant { get; set; }
    }
}
