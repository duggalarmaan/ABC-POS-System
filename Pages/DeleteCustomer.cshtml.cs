using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Site_Project.Domain;

namespace Web_Site_Project.Pages
{
    public class DeleteCustomerModel : PageModel
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
                ABCPOS.RemoveCustomer(New_Customer);
                Message = "Customer #'" + New_Customer.CustomerID + "' was deleted from Customers table.";

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }

        }
    }
}
