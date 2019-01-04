using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderViewModel
    {
        public int BillID { set; get; }
        public int ProdID { set; get; }
        public string ProdName { set; get; }
        public int Count { set; get; }
        public DateTime? CreatedAt { set; get; }
        public DateTime? UpdatedAt { set; get; }
        public int OrderID { set; get; }
    }
}
