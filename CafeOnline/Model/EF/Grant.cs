namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grant")]
    public partial class Grant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grant()
        {
            Users = new HashSet<User>();
        }

        public int GrantID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Tên phân quyền")]
        public string GrantName { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool isActive { get; set; }

        [Display(Name = "Thời gian tạo")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Thời gian chỉnh sửa")]
        public DateTime? UpdatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
