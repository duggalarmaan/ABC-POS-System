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
    public class Items
    {
        public static bool AddItem(Item NewItem)
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
            comm.CommandText = "AddItem";

            //Set's up each required parameter for the stored procedure.
            SqlParameter item_code = new SqlParameter();
            item_code.Value = NewItem.ItemCode;
            item_code.SqlDbType = SqlDbType.NVarChar;
            item_code.Size = 10;
            item_code.ParameterName = "@ItemCode";
            comm.Parameters.Add(item_code);

            SqlParameter description = new SqlParameter();
            description.Value = NewItem.Description;
            description.SqlDbType = SqlDbType.NVarChar;
            description.Size = 60;
            description.ParameterName = "@Description";
            comm.Parameters.Add(description);

            SqlParameter unit_price = new SqlParameter();
            unit_price.Value = NewItem.UnitPrice;
            unit_price.SqlDbType = SqlDbType.Money;
            unit_price.ParameterName = "@UnitPrice";
            comm.Parameters.Add(unit_price);

            SqlParameter stock = new SqlParameter();
            stock.Value = NewItem.QauntityInStock;
            stock.SqlDbType = SqlDbType.Int;
            stock.ParameterName = "@QuantityInStock";
            comm.Parameters.Add(stock);

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

        public static bool UpdateItem(Item NewItem)
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
            comm.CommandText = "UpdateItem";

            //Set's up each required parameter for the stored procedure.
            SqlParameter item_code = new SqlParameter();
            item_code.Value = NewItem.ItemCode;
            item_code.SqlDbType = SqlDbType.NVarChar;
            item_code.Size = 10;
            item_code.ParameterName = "@ItemCode";
            comm.Parameters.Add(item_code);

            SqlParameter description = new SqlParameter();
            description.Value = NewItem.Description;
            description.SqlDbType = SqlDbType.NVarChar;
            description.Size = 60;
            description.ParameterName = "@Description";
            comm.Parameters.Add(description);

            SqlParameter unit_price = new SqlParameter();
            unit_price.Value = NewItem.UnitPrice;
            unit_price.SqlDbType = SqlDbType.Money;
            unit_price.ParameterName = "@UnitPrice";
            comm.Parameters.Add(unit_price);

            SqlParameter stock = new SqlParameter();
            stock.Value = NewItem.QauntityInStock;
            stock.SqlDbType = SqlDbType.Int;
            stock.ParameterName = "@QuantityInStock";
            comm.Parameters.Add(stock);

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

        public static bool DeleteItem(Item NewItem)
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
            comm.CommandText = "DeleteItem";

            //Set's up each required parameter for the stored procedure.
            SqlParameter item_code = new SqlParameter();
            item_code.Value = NewItem.ItemCode;
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

        public static Item GetItem(Item NewItem)
        {
            Item temp_item = new Item();

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
            comm.CommandText = "GetItem";

            //Set's up each required parameter for the stored procedure.
            SqlParameter item_code = new SqlParameter();
            item_code.Value = NewItem.ItemCode;
            item_code.SqlDbType = SqlDbType.NVarChar;
            item_code.Size = 10;
            item_code.ParameterName = "@ItemCode";
            comm.Parameters.Add(item_code);

            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {               

                    //temp_item.ItemCode = reader["ItemCode"].ToString();
                    temp_item.Description = reader["Description"].ToString();
                    temp_item.UnitPrice = (decimal)reader["UnitPrice"];
                    temp_item.QauntityInStock = (int)reader["QuantityInStock"];                    
                
            }


            reader.Close();
            BAIS3150.Close();

            return temp_item;
        }

        public static List<Item> GetAllItems()
        {
            List<Item> AllItems = new List<Item>();

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
            comm.CommandText = "GetAllItems";

            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Item temp_item = new Item();

                    temp_item.ItemCode = reader["ItemCode"].ToString();
                    temp_item.Description = reader["Description"].ToString();
                    temp_item.UnitPrice = (decimal)reader["UnitPrice"];
                    temp_item.QauntityInStock = (int)reader["QuantityInStock"];                   

                    AllItems.Add(temp_item);
                }
            }


            reader.Close();
            BAIS3150.Close();

            return AllItems;
        }
    }
}
