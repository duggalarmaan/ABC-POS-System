using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_Site_Project.Domain;
namespace Web_Site_Project.TechnicalServices
{
    public class Sales
    {
        public static int AddSale(Sale ABCSale)
        {
            //Opens a connection with the database
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            //Inititiate and specifies the command to the database
            SqlCommand comm = new SqlCommand();
            comm.Connection = BAIS3150;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "ProcessSale";

            //Set's up each required parameter for the stored procedure.

            SqlParameter Sale_Date = new SqlParameter();
            Sale_Date.Value = ABCSale.SaleDate;
            Sale_Date.SqlDbType = SqlDbType.Date;
            Sale_Date.ParameterName = "@SaleDate";
            comm.Parameters.Add(Sale_Date);

            SqlParameter Salesperson_id = new SqlParameter();
            Salesperson_id.Value = ABCSale.SalespersonID;
            Salesperson_id.SqlDbType = SqlDbType.Int;            
            Salesperson_id.ParameterName = "@SalespersonID";
            comm.Parameters.Add(Salesperson_id);

            SqlParameter customer_id = new SqlParameter();
            customer_id.Value = ABCSale.CustomerID;
            customer_id.SqlDbType = SqlDbType.Int;
            customer_id.ParameterName = "@CustomerID";
            comm.Parameters.Add(customer_id);

            SqlParameter sub_total = new SqlParameter();
            sub_total.Value = ABCSale.SubTotal;
            sub_total.SqlDbType = SqlDbType.Money;
            sub_total.ParameterName = "@SubTotal";
            comm.Parameters.Add(sub_total);

            SqlParameter GST = new SqlParameter();
            GST.Value = ABCSale.GST;
            GST.SqlDbType = SqlDbType.Money;
            GST.ParameterName = "@GST";
            comm.Parameters.Add(GST);

            SqlParameter Sale_Total = new SqlParameter();
            Sale_Total.Value = ABCSale.SaleTotal;
            Sale_Total.SqlDbType = SqlDbType.Money;
            Sale_Total.ParameterName = "@SaleTotal";
            comm.Parameters.Add(Sale_Total);

            SqlParameter status = new SqlParameter();           
            status.SqlDbType = SqlDbType.Int;
            status.ParameterName = "@status";
            status.Direction = ParameterDirection.Output;
            comm.Parameters.Add(status);

            SqlParameter returnValue = new SqlParameter();
            returnValue.Value = -1;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(returnValue);

            //Execute the command 
            comm.ExecuteNonQuery();

            return (int)status.Value;
        }

        public static bool AddCart(CustomerCart CartItem)
        {
            //Opens a connection with the database
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            //Inititiate and specifies the command to the database
            SqlCommand comm = new SqlCommand();
            comm.Connection = BAIS3150;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "AddtoCustomerCart";

            //Set's up each required parameter for the stored procedure.

            SqlParameter customer_id = new SqlParameter();
            customer_id.Value = CartItem.CustomerID;
            customer_id.SqlDbType = SqlDbType.Int;            
            customer_id.ParameterName = "@CustomerID";
            comm.Parameters.Add(customer_id);

            SqlParameter item_code = new SqlParameter();
            item_code.Value = CartItem.ItemCode;
            item_code.SqlDbType = SqlDbType.NVarChar;
            item_code.Size = 10;
            item_code.ParameterName = "@ItemCode";
            comm.Parameters.Add(item_code);           

            SqlParameter quantity = new SqlParameter();
            quantity.Value = (int)CartItem.Quantity;
            quantity.SqlDbType = SqlDbType.Int;
            quantity.ParameterName = "@Quantity";
            comm.Parameters.Add(quantity);

            SqlParameter item_total = new SqlParameter();
            item_total.Value = CartItem.ItemTotal;
            item_total.SqlDbType = SqlDbType.Money;
            item_total.ParameterName = "@ItemTotal";
            comm.Parameters.Add(item_total);

            SqlParameter returnValue = new SqlParameter();
            returnValue.Value = -1;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(returnValue);

            //Execute the command 
            comm.ExecuteNonQuery();

            if ((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool RemoveCart(CustomerCart CartItem)
        {
            //Opens a connection with the database
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            //Inititiate and specifies the command to the database
            SqlCommand comm = new SqlCommand();
            comm.Connection = BAIS3150;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "DeletefromCustomerCart";

            //Set's up each required parameter for the stored procedure.

            SqlParameter customer_id = new SqlParameter();
            customer_id.Value = CartItem.CustomerID;
            customer_id.SqlDbType = SqlDbType.Int;
            customer_id.ParameterName = "@CustomerID";
            comm.Parameters.Add(customer_id);

            SqlParameter item_code = new SqlParameter();
            item_code.Value = CartItem.ItemCode;
            item_code.SqlDbType = SqlDbType.NVarChar;
            item_code.Size = 10;
            item_code.ParameterName = "@ItemCode";
            comm.Parameters.Add(item_code);
            
            SqlParameter returnValue = new SqlParameter();
            returnValue.Value = -1;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(returnValue);

            //Execute the command 
            comm.ExecuteNonQuery();

            if ((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static List<CustomerCart> GetCart(int cust_id)
        {
            List<CustomerCart> cartlist = new List<CustomerCart>();

            //Opens a connection with the database
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            //Inititiate and specifies the command to the database
            SqlCommand comm = new SqlCommand();
            comm.Connection = BAIS3150;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "GetCustomerCart";

            //Set's up each required parameter for the stored procedure.

            SqlParameter customer_id = new SqlParameter();
            customer_id.Value = cust_id;
            customer_id.SqlDbType = SqlDbType.Int;           
            customer_id.ParameterName = "@CustomerID";
            comm.Parameters.Add(customer_id);


            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CustomerCart  temp_cart = new CustomerCart();

                    temp_cart.CustomerID = (int)reader["CustomerID"];
                    temp_cart.ItemCode = reader["ItemCode"].ToString();
                    temp_cart.Quantity = (int)reader["Quantity"];
                    temp_cart.ItemTotal = (decimal)reader["ItemTotal"];

                    cartlist.Add(temp_cart);
                }
            }


            reader.Close();
            BAIS3150.Close();

            return cartlist;

        }

        public static bool AddSOD(SaleOrderDetail SOD, int cust_id)
        {
            //Opens a connection with the database
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            //Inititiate and specifies the command to the database
            SqlCommand comm = new SqlCommand();
            comm.Connection = BAIS3150;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "AddtoSaleOrderDetail";

            //Set's up each required parameter for the stored procedure.
            SqlParameter customer_id = new SqlParameter();
            customer_id.Value = cust_id;
            customer_id.SqlDbType = SqlDbType.Int;
            customer_id.ParameterName = "@CustomerID";
            comm.Parameters.Add(customer_id);

            SqlParameter sale_num = new SqlParameter();
            sale_num.Value = SOD.SaleNumber;
            sale_num.SqlDbType = SqlDbType.Int;
            sale_num.ParameterName = "@SaleNumber";
            comm.Parameters.Add(sale_num);

            SqlParameter item_code = new SqlParameter();
            item_code.Value = SOD.ItemCode;
            item_code.SqlDbType = SqlDbType.NVarChar;
            item_code.Size = 10;
            item_code.ParameterName = "@ItemCode";
            comm.Parameters.Add(item_code);

            SqlParameter quantity = new SqlParameter();
            quantity.Value = SOD.Quantity;
            quantity.SqlDbType = SqlDbType.Int;
            quantity.ParameterName = "@Quantity";
            comm.Parameters.Add(quantity);

            SqlParameter item_total = new SqlParameter();
            item_total.Value = SOD.ItemTotal;
            item_total.SqlDbType = SqlDbType.Money;
            item_total.ParameterName = "@ItemTotal";
            comm.Parameters.Add(item_total);

            SqlParameter returnValue = new SqlParameter();
            returnValue.Value = -1;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(returnValue);

            //Execute the command 
            comm.ExecuteNonQuery();

            if ((int)returnValue.Value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static Employee GetEmployee(Employee NewEmployee)
        {
            Employee temp_employee = new Employee();

            //Opens a connection with the database
            ConfigurationBuilder DatabaseUsersBuilder = new();
            DatabaseUsersBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUsersBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUsersConfiguration = DatabaseUsersBuilder.Build();

            SqlConnection BAIS3150 = new();
            BAIS3150.ConnectionString = DatabaseUsersConfiguration.GetConnectionString("BAIS3150");
            BAIS3150.Open();

            //Inititiate and specifies the command to the database
            SqlCommand comm = new SqlCommand();
            comm.Connection = BAIS3150;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "GetEmployee";

            //Set's up each required parameter for the stored procedure.
            SqlParameter salesperson_id = new SqlParameter();
            salesperson_id.Value = NewEmployee.SalespersonID;
            salesperson_id.SqlDbType = SqlDbType.Int;
            salesperson_id.ParameterName = "@SalespersonID";
            comm.Parameters.Add(salesperson_id);

            SqlParameter returnValue = new SqlParameter();
            returnValue.Value = -1;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(returnValue);

            //Execute the command 
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                NewEmployee.SalespersonID = (int)reader["SalespersonID"];
                NewEmployee.Salesperson = reader["Salesperson"].ToString();             
            }

            reader.Close();
            BAIS3150.Close();

            return temp_employee;

        }

    }
}
