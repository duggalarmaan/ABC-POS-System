using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Site_Project.Domain;

namespace Web_Site_Project.Pages
{
    public class DeleteItemModel : PageModel
    {
        [BindProperty]
        public Item New_Item { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public void Onpost()
        {
            try
            {
                ABCPOS.RemoveItem(New_Item);
                Message = "Item '" + New_Item.ItemCode + "' was deleted from Items table.";

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }

        }
    }
}
