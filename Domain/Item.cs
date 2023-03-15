using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Site_Project.Domain
{
    public class Item
    {        
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int QauntityInStock { get; set; }
    }
}
