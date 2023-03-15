using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Site_Project.Domain
{
    public class Sale
    {
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public int SalespersonID { get; set; }
        public int CustomerID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GST { get; set; }
        public decimal SaleTotal { get; set; }
    }
}
