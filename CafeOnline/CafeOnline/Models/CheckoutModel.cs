using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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