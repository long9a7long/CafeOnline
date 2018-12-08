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
            Order = new HashSet<Order>();
        }

        [Key]
        [Display(Name ="Mã sản phẩm")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProdID { get; set; }

        [Required]
        [Display(Name = "Tên sản phẩm")]
        [StringLength(200)]
        public string ProdName { get; set; }

        [StringLength(4000)]
        [Display(Name = "Ảnh sản phẩm")]
        public string ImageUrl { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Decription { get; set; }

        [Display(Name = "Giá")]
        public int Cost { get; set; }

        [Display(Name = "Trạng thái")]
        public bool isActive { get; set; }

        [Display(Name = "Danh mục sản phẩm")]
        public byte CateID { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Ngày sửa gần nhất")]
        public DateTime? UpdatedAt { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
