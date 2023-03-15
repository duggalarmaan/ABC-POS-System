using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Site_Project.Domain
{
    public class SaleOrderDetail
    {
        public int SaleNumber { get; set; }
        public string ItemCode { get; set; }    
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }
    }
}
