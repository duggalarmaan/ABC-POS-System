
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Site_Project.Domain;

namespace Web_Site_Project.Pages
{
    public class ProcessSaleModel : PageModel
    {
        [BindProperty]
        public bool state1 { get; set; }
        [BindProperty]
        public bool state2 { get; set; }
        [BindProperty]
        public bool state3 { get; set; }
        [BindProperty]
        public List<Item> All_Items { get; set; }
        [BindProperty]
        public List<CustomerCart> Process_Sale_CustomerCart_List { get; set; } = new List<CustomerCart>();
        [BindProperty]
        public Employee Process_Sale_Employee { get; set; }
        [BindProperty]
        public Customer Process_Sale_Customer { get; set; }        
        [BindProperty]
        public Item Process_Sale_Item { get; set; }
        [BindProperty]
        public CustomerCart Process_Sale_CustomerCart { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public Sale Process_Sale { get; set; }

        public List<SaleOrderDetail> Process_Sale_OrderDetail_List { get; set; } = new List<SaleOrderDetail>();

        public void OnGet()
        {
            state1 = true;
        }

        public void OnPostSubmitEmployee()
        {
            //Check if Employee Exist then add customer information
            try
            {
                Process_Sale_Employee = ABCPOS.FindEmployee(Process_Sale_Employee);
            }
            catch (Exception ex)
            {
                state1 = true;
                Message = ex.Message;
                return;
            }

            try
            {
                Process_Sale_Customer = ABCPOS.FindCustomer(Process_Sale_Customer);
            }
            catch (Exception ex)
            {
                state1 = true;
                Message = ex.Message;
                return;
            }

            state1 = false;
            state2 = true;
            state3 = true;

            try
            {
                Process_Sale_CustomerCart_List = ABCPOS.GetCustomerCart(Process_Sale_Customer.CustomerID);

                if (Process_Sale_CustomerCart_List.Count > 0)
                {
                    foreach (var item in Process_Sale_CustomerCart_List)
                    {
                        Process_Sale.SubTotal += Math.Round(item.ItemTotal, 2);
                    }

                    Process_Sale.GST = Math.Round((Process_Sale.SubTotal * (decimal)0.07), 2);
                    Process_Sale.SaleTotal = Math.Round((Process_Sale.SubTotal + Process_Sale.GST), 2);
                }
               
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }

        }
        public void OnPostSubmitItem()
        {           

            All_Items = ABCPOS.GetItems();
            
            int index = All_Items.FindIndex(x => x.ItemCode.Equals(Process_Sale_Item.ItemCode));
            if (index != -1)
            {
                Process_Sale_Item.ItemCode = All_Items[index].ItemCode;
                Process_Sale_Item.Description = All_Items[index].Description;
                Process_Sale_Item.UnitPrice = All_Items[index].UnitPrice;
                Process_Sale_Item.QauntityInStock = All_Items[index].QauntityInStock;
            }
            else
            {
                Message = "Item not found. Please ensure the ItemCode is in the following format: [A-Z][0-9][0-9][0-9][0-9][0-9]";
            }

            try
            {

                Process_Sale_CustomerCart_List = ABCPOS.GetCustomerCart(Process_Sale_Customer.CustomerID);

                if (Process_Sale_CustomerCart_List.Count > 0)
                {
                    foreach (var item in Process_Sale_CustomerCart_List)
                    {
                        Process_Sale.SubTotal += Math.Round(item.ItemTotal, 2);
                    }

                    Process_Sale.GST = Math.Round((Process_Sale.SubTotal * (decimal)0.07), 2);
                    Process_Sale.SaleTotal = Math.Round((Process_Sale.SubTotal + Process_Sale.GST), 2);
                }
            }
            catch (Exception)
            {
                //Message = ex.Message;
                //return;
            }

            state1 = false;
            state2 = true;
            state3 = true;
        }
        public void OnPostAddItem()
        {
            state1 = false;
            state2 = true;
            state3 = true;

            All_Items = ABCPOS.GetItems();

            int index = All_Items.FindIndex(x => x.ItemCode == Process_Sale_Item.ItemCode);
            if (index != -1)
            {
                Process_Sale_Item.ItemCode = All_Items[index].ItemCode;
                Process_Sale_Item.Description = All_Items[index].Description;
                Process_Sale_Item.UnitPrice = All_Items[index].UnitPrice;
                Process_Sale_Item.QauntityInStock = All_Items[index].QauntityInStock;
            }
            else
            {
                Message = "Item not found. Please ensure the ItemCode is in the following format: [A-Z][0-9][0-9][0-9][0-9][0-9]";
                return;
            }


            if (Process_Sale_CustomerCart.Quantity > Process_Sale_Item.QauntityInStock)
            {
                Message = "The quantity you asked for is not in stock.";

                return;
            }

            Process_Sale_CustomerCart.CustomerID = Process_Sale_Customer.CustomerID;
            Process_Sale_CustomerCart.ItemCode = Process_Sale_Item.ItemCode;
            Process_Sale_CustomerCart.ItemTotal = Process_Sale_Item.UnitPrice * Process_Sale_CustomerCart.Quantity;


            try
            {
                ABCPOS.AddtoCart(Process_Sale_CustomerCart);
                Message = "Item '" + Process_Sale_CustomerCart.ItemCode + "' was added to your cart.";

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }

            try
            {               

                Process_Sale_CustomerCart_List = ABCPOS.GetCustomerCart(Process_Sale_Customer.CustomerID);

                if (Process_Sale_CustomerCart_List.Count > 0)
                {
                    foreach (var item in Process_Sale_CustomerCart_List)
                    {
                        Process_Sale.SubTotal += Math.Round(item.ItemTotal, 2);
                    }

                    Process_Sale.GST = Math.Round((Process_Sale.SubTotal * (decimal)0.07), 2);
                    Process_Sale.SaleTotal = Math.Round((Process_Sale.SubTotal + Process_Sale.GST), 2);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }           
           
            
        }

        public void OnPostRemoveItem()
        {
            state1 = false;
            state2 = true;
            state3 = true;

            if (Process_Sale_Item.ItemCode == null)
            {
                Message = "Please enter an ItemCode. Please ensure the ItemCode is in the following format: [A-Z][0-9][0-9][0-9][0-9][0-9]";
                return;
            }

            Process_Sale_CustomerCart.CustomerID = Process_Sale_Customer.CustomerID;
            Process_Sale_CustomerCart.ItemCode = Process_Sale_Item.ItemCode;
            Process_Sale_CustomerCart.ItemTotal = Process_Sale_Item.UnitPrice * Process_Sale_CustomerCart.Quantity;

            try
            {
                ABCPOS.DeletefromCart(Process_Sale_CustomerCart);
                Message = "Item '" + Process_Sale_CustomerCart.ItemCode + "' was removed from your cart.";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }

            try
            {

                Process_Sale_CustomerCart_List = ABCPOS.GetCustomerCart(Process_Sale_Customer.CustomerID);

                if (Process_Sale_CustomerCart_List.Count > 0)
                {
                    foreach (var item in Process_Sale_CustomerCart_List)
                    {
                        Process_Sale.SubTotal += Math.Round(item.ItemTotal, 2);
                    }

                    Process_Sale.GST = Math.Round((Process_Sale.SubTotal * (decimal)0.07), 2);
                    Process_Sale.SaleTotal = Math.Round((Process_Sale.SubTotal + Process_Sale.GST), 2);
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return;
            }
        }

        public void OnPostSubmitSale()
        {
            Process_Sale.SaleDate = DateTime.Today;
            Process_Sale.SalespersonID = Process_Sale_Employee.SalespersonID;
            Process_Sale.CustomerID = Process_Sale_Customer.CustomerID;

            int temp_salenum = ABCPOS.ProcessSale(Process_Sale);

            try
            {
                Process_Sale_CustomerCart_List = ABCPOS.GetCustomerCart(Process_Sale_Customer.CustomerID);
                Message = "Transaction #" + temp_salenum + " was succesfully completed. <br> Thankyou for shopping at ABC Hardware.";
            }
            catch (Exception ex)
            {
                state1 = false;
                state2 = true;
                state3 = true;
                Message = ex.Message + "<br> Please add item's in your cart before processing sale.";
                return;
            }
                        
            foreach (CustomerCart item in Process_Sale_CustomerCart_List)
            {
                SaleOrderDetail temp_OD = new SaleOrderDetail();
                temp_OD.SaleNumber = temp_salenum;
                temp_OD.ItemCode = item.ItemCode;
                temp_OD.Quantity = item.Quantity;
                temp_OD.ItemTotal = item.ItemTotal;

                Process_Sale_OrderDetail_List.Add(temp_OD);
            }

            foreach (SaleOrderDetail item in Process_Sale_OrderDetail_List)
            {
                try
                {
                    ABCPOS.AddToSOD(item, Process_Sale.CustomerID);
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    return;
                }
                
            }
        }


    }
}
