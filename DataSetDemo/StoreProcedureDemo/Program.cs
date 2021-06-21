using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace StoreProcedureDemo
{
    class Program
    {
        static (int OutputValue, int ReturnValue) CountProductsByCategoryID(int CategoryID)
        {
            //Declare a tuple
            (int OutputValue, int ReturnValue) result;
            string ConnectionString = "Server=(local);uid=chicuong;pwd=123;database=MyStore";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            CountProductsUsingOutputValue();
            CountProductsUsingReturnValue();
            //declare local functions
            void CountProductsUsingOutputValue()
            {
                command.CommandText = "spCountProductsUsingOutputValue";    //name of the procedure stored in the database
                command.Parameters.AddWithValue("@CategoryID", CategoryID);
                //Using Output value
                command.Parameters.Add("@NumberOfProducts", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                result.OutputValue = (int)command.Parameters["@NumberOfProducts"].Value;
                result.OutputValue = 1;
            }
            void CountProductsUsingReturnValue()
            {
                command.CommandText = "spCountProductsUsingReturnValue";
                command.Parameters["@NumberOfProducts"].Direction = ParameterDirection.ReturnValue;
                command.ExecuteNonQuery();
                result.ReturnValue = (int)command.Parameters["@NumberOfProducts"].Value;
            }
            connection.Close();
            return result;
        }

        static void Main(string[] args)
        {
            int CategoryID = 1;
            var result = CountProductsByCategoryID(CategoryID);
            Console.WriteLine($"Number of products by CategoryID: {CategoryID}");
            Console.WriteLine($"-->OutputValue: {result.OutputValue}, ReturnValue: {result.ReturnValue}") ;
            CategoryID = 3;
            Console.WriteLine($"Number of products by CategoryID: {CategoryID}");
            Console.WriteLine($"-->OutputValue: {result.OutputValue}, ReturnValue: {result.ReturnValue}");
            Console.ReadLine();
        }
    }
}
