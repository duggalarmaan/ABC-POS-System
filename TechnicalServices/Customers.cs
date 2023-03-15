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
    public class Customers
    {
        public static int AddCustomer(Customer NewCustomer)
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
            comm.CommandText = "AddCustomer";

            //Set's up each required parameter for the stored procedure.
            SqlParameter cust_name = new SqlParameter();
            cust_name.Value = NewCustomer.CustomerName;
            cust_name.SqlDbType = SqlDbType.NVarChar;
            cust_name.Size = 50;
            cust_name.ParameterName = "@CustomerName";
            comm.Parameters.Add(cust_name);

            SqlParameter cust_address = new SqlParameter();
            cust_address.Value = NewCustomer.Address;
            cust_address.SqlDbType = SqlDbType.NVarChar;
            cust_address.Size = 50;
            cust_address.ParameterName = "@Address";
            comm.Parameters.Add(cust_address);

            SqlParameter cust_city = new SqlParameter();
            cust_city.Value = NewCustomer.City;
            cust_city.SqlDbType = SqlDbType.NVarChar;
            cust_city.Size = 50;
            cust_city.ParameterName = "@City";
            comm.Parameters.Add(cust_city);

            SqlParameter cust_province = new SqlParameter();
            cust_province.Value = NewCustomer.Province;
            cust_province.SqlDbType = SqlDbType.NVarChar;
            cust_province.Size = 50;
            cust_province.ParameterName = "@Province";
            comm.Parameters.Add(cust_province);

            SqlParameter cust_postal = new SqlParameter();
            cust_postal.Value = NewCustomer.PostalCode;
            cust_postal.SqlDbType = SqlDbType.NVarChar;
            cust_postal.Size = 50;
            cust_postal.ParameterName = "@PostalCode";
            comm.Parameters.Add(cust_postal);
           
            SqlParameter returnValue = new SqlParameter();
            returnValue.Value = -1;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(returnValue);

            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.Int;
            status.ParameterName = "@status";
            status.Direction = ParameterDirection.Output;
            comm.Parameters.Add(status);

            //Execute the command 
            comm.ExecuteNonQuery();

            return (int)status.Value;

        }

        public static bool UpdateCustomer(Customer NewCustomer)
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
            comm.CommandText = "UpdateCustomer";

            //Set's up each required parameter for the stored procedure.
            SqlParameter cust_id = new SqlParameter();
            cust_id.Value = NewCustomer.CustomerID;
            cust_id.SqlDbType = SqlDbType.Int;      
            cust_id.ParameterName = "@CustomerID";
            comm.Parameters.Add(cust_id);

            SqlParameter cust_name = new SqlParameter();
            cust_name.Value = NewCustomer.CustomerName;
            cust_name.SqlDbType = SqlDbType.NVarChar;
            cust_name.Size = 50;
            cust_name.ParameterName = "@CustomerName";
            comm.Parameters.Add(cust_name);

            SqlParameter cust_address = new SqlParameter();
            cust_address.Value = NewCustomer.Address;
            cust_address.SqlDbType = SqlDbType.NVarChar;
            cust_address.Size = 50;
            cust_address.ParameterName = "@Address";
            comm.Parameters.Add(cust_address);

            SqlParameter cust_city = new SqlParameter();
            cust_city.Value = NewCustomer.City;
            cust_city.SqlDbType = SqlDbType.NVarChar;
            cust_city.Size = 50;
            cust_city.ParameterName = "@City";
            comm.Parameters.Add(cust_city);

            SqlParameter cust_province = new SqlParameter();
            cust_province.Value = NewCustomer.Province;
            cust_province.SqlDbType = SqlDbType.NVarChar;
            cust_province.Size = 50;
            cust_province.ParameterName = "@Province";
            comm.Parameters.Add(cust_province);

            SqlParameter cust_postal = new SqlParameter();
            cust_postal.Value = NewCustomer.PostalCode;
            cust_postal.SqlDbType = SqlDbType.NVarChar;
            cust_postal.Size = 50;
            cust_postal.ParameterName = "@PostalCode";
            comm.Parameters.Add(cust_postal);

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

        public static bool DeleteCustomer(Customer NewCustomer)
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
            comm.CommandText = "DeleteCustomer";

            //Set's up each required parameter for the stored procedure.
            SqlParameter cust_id = new SqlParameter();
            cust_id.Value = NewCustomer.CustomerID;
            cust_id.SqlDbType = SqlDbType.Int;      
            cust_id.ParameterName = "@CustomerID";
            comm.Parameters.Add(cust_id);
           
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

        public static Customer GetCustomer(Customer NewCustomer)
        {
            Customer temp_cust = new Customer();

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
            comm.CommandText = "GetCustomer";

            //Set's up each required parameter for the stored procedure.
            SqlParameter cust_id = new SqlParameter();
            cust_id.Value = NewCustomer.CustomerID;
            cust_id.SqlDbType = SqlDbType.Int;
            cust_id.ParameterName = "@CustomerID";
            comm.Parameters.Add(cust_id);

            SqlParameter returnValue = new SqlParameter();
            returnValue.Value = -1;
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(returnValue);

            //Execute the command 
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {

                temp_cust.CustomerID = (int)reader["CustomerID"];
                temp_cust.CustomerName = reader["CustomerName"].ToString();
                temp_cust.Address = reader["Address"].ToString();
                temp_cust.City = reader["City"].ToString();
                temp_cust.Province = reader["Province"].ToString();
                temp_cust.PostalCode = reader["PostalCode"].ToString();

            }


            reader.Close();
            BAIS3150.Close();

            return temp_cust;

        }       
    }
}
