using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.IO;

namespace DatabaseDemoMyStore
{
    class Program
    {
        static string GetConnectionsString()
        {
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
            var strConnection = config["ConnectionString:MyStoreDB"];
            return strConnection;
        }

        static void ViewProducts()
        {
            DbProviderFactory factory = SqlClientFactory.Instance;
            //get the connection obj
            using DbConnection connection = factory.CreateConnection();
            if(connection == null)
            {
                Console.WriteLine("Unable to create the connection object");
                return;
            }
            connection.ConnectionString = GetConnectionsString();
            connection.Open();
            DbCommand command = factory.CreateCommand();    //PrepareStatement
            if(command == null)
            {
                Console.WriteLine("Unable to create the command object.");
                return;
            }
            command.Connection = connection;
            command.CommandText = "SELECT Product.ProductID, Product.ProductName, Category.CategoryName\n" +
                "FROM Product INNER JOIN Category ON Product.CategoryID = Category.CategoryID";
            //Print out data with data reader
            using DbDataReader dataReader = command.ExecuteReader();
            Console.WriteLine("***** Product List *****");
            while (dataReader.Read())
            {
                Console.WriteLine($"ProductID: {dataReader["ProductID"]}, " 
                    + $"ProductName: {dataReader["ProductName"]}, Category: {dataReader["CategoryName"]}");
            }

        }
        static void Main(string[] args)
        {
            ViewProducts();
            Console.ReadLine();
        }
    }
}
