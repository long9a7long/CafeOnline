using System.ComponentModel.DataAnnotations;

namespace CafeOnline.Models
{
    public class CheckoutModel
    {
        [Key]
        public string DeliveryAddress { get; set; }

        public string Phone { get; set; }
    }
}