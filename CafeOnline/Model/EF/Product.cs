namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        [Display(Name ="Mã Sản phẩm")]
        [Key]
        public int ProdID { get; set; }

        [Required]
        [Display(Name = "Tên Sản phẩm")]
        [StringLength(200)]
        public string ProdName { get; set; }

        [StringLength(4000)]
        [Display(Name = "Ảnh Sản phẩm")]
        public string ImageUrl { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Decription { get; set; }

        [Display(Name = "Giá")]
        public int Cost { get; set; }

        [Display(Name = "Trạng thái")]
        public bool isActive { get; set; }

        [Display(Name = "Mã Danh mục")]
        public int CateID { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Ngày sửa")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Danh mục")]
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
