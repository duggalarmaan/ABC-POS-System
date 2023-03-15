using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Site_Project.Domain;

namespace Web_Site_Project.Pages
{
    public class UpdateCustomerModel : PageModel
    {
        [BindProperty]
        public bool state { get; set; } = true;
        [BindProperty]
        public Customer New_Customer { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public void OnpostGetCustomer()
        {
            try
            {
                New_Customer = ABCPOS.FindCustomer(New_Customer);
                
                state = false;
            }
            catch (Exception ex)
            {
                state = true;
                Message = ex.Message;
                return;
            }
        }

        public void OnpostUpdateCustomer()
        {
            try
            {
                ABCPOS.ModifyCustomer(New_Customer);
                Message = "CustomerID #'" + New_Customer.CustomerID + "' was updated in Customers table. <br><br> UPDATED CUSTOMER:<br>Name: "
                    + New_Customer.CustomerName + "<br>Address: " + New_Customer.Address + "<br>City: " + New_Customer.City
                    + "<br>Province: " + New_Customer.Province + "<br>Postal Code: " + New_Customer.PostalCode;

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }

        }

    }
}
