using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Site_Project.Domain;

namespace Web_Site_Project.Pages
{
    public class UpdateItemModel : PageModel
    {
        [BindProperty]
        public bool state { get; set; } = true;
        [BindProperty]
        public Item New_Item { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public void OnPostGetItem()
        {
            try
            {
                Item temp = ABCPOS.FindItem(New_Item);
                New_Item.Description = temp.Description;               
                New_Item.UnitPrice = temp.UnitPrice;
                New_Item.QauntityInStock = temp.QauntityInStock;
                state = false;
            }
            catch (Exception ex)
            {
                state = true;
                Message = ex.Message;
                return;
            }
        
        }

        public void OnPostUpdateItem()
        {
            try
            {
                ABCPOS.ModifyItem(New_Item);
                Message = "Item '" + New_Item.ItemCode + "' was updated in Items table. <br><br> UPDATED ITEM:<br>Item Code: " 
                    + New_Item.ItemCode + "<br>Description: " + New_Item.Description + "<br>UnitPrice: " + New_Item.UnitPrice + "<br>QauntityInStock: " + New_Item.QauntityInStock;

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }

        }

    }
}
