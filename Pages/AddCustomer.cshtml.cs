using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Site_Project.Domain;

namespace Web_Site_Project.Pages
{
    public class AddCustomerModel : PageModel
    {

        [BindProperty]
        public Customer New_Customer { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public void Onpost()
        {
            try
            {
                int cust_id = ABCPOS.CreateCustomer(New_Customer);
                Message = "'"+ New_Customer.CustomerName + "' was added to the Customer table with Customer ID '" + cust_id + "' .";

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }

        }
    }
}
