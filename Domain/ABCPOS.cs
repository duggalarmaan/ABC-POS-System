using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Site_Project.TechnicalServices;

namespace Web_Site_Project.Domain
{
    public class ABCPOS
    {
        public static bool CreateItem(Item NewItem)
        {
            return Items.AddItem(NewItem);
        }

        public static bool ModifyItem(Item NewItem)
        {
            return Items.UpdateItem(NewItem);
        }

        public static bool RemoveItem(Item NewItem)
        {
            return Items.DeleteItem(NewItem);
        }
        public static Item FindItem(Item NewItem)
        {
            return Items.GetItem(NewItem);
        }

        public static int CreateCustomer(Customer NewCustomer)
        {
            return Customers.AddCustomer(NewCustomer);
        }

        public static bool ModifyCustomer(Customer NewCustomer)
        {
            return Customers.UpdateCustomer(NewCustomer);
        }

        public static bool RemoveCustomer(Customer NewCustomer)
        {
            return Customers.DeleteCustomer(NewCustomer);
        }

        public static Customer FindCustomer(Customer NewCustomer)
        {
            return Customers.GetCustomer(NewCustomer);
        }

        public static Employee FindEmployee(Employee NewEmployee)
        {
            return Sales.GetEmployee(NewEmployee);
        }

        public static List<Item> GetItems()
        {
            return Items.GetAllItems();
        }

        public static bool AddtoCart(CustomerCart CartItem)
        {
            return Sales.AddCart(CartItem);
        }

        public static bool DeletefromCart(CustomerCart CartItem)
        {
            return Sales.RemoveCart(CartItem);
        }

        public static List<CustomerCart> GetCustomerCart(int customer_id)
        {
            return Sales.GetCart(customer_id);
        }

        public static int ProcessSale(Sale ABCSale)
        {
            return Sales.AddSale(ABCSale);
        }

        public static bool AddToSOD(SaleOrderDetail SOD, int cust_id)
        {
            return Sales.AddSOD(SOD, cust_id);
        }
    }
}
