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
            Bill = new HashSet<Bill>();
        }

        [Display(Name ="Tên Đăng Nhập")]
        [StringLength(50)]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "Mật Khẩu")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên Hiển Thị")]
        public string FullName { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; }

        [StringLength(50)]

        public string Email { get; set; }

        [Display(Name = "Quyền")]
        public byte GrantID { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool isActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bill { get; set; }

        public virtual Grant Grant { get; set; }
    }
}
