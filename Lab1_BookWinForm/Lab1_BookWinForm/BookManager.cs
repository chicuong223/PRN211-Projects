using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_BookWinForm
{
    public class BookManager
    {
        string strConnection;
        public BookManager()
        {
            strConnection = getConnectionString();
        }
        public string getConnectionString()
        {
            string strConnection = "server=DESKTOP-T5I6O1J;database=BooksManagement;uid=chicuong;pwd=123";
            return strConnection;
        }

        //get All Books from the database
        public DataTable getBooks()
        {
            string SQL = "SELECT * FROM Book";
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtBook = new DataTable();
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }  
                //Put data from adapter into data table
                da.Fill(dtBook);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dtBook;
        }

        public bool AddBook(Book book)
        {
            SqlConnection con = new SqlConnection(strConnection);
            string SQL = "INSERT Book VALUES(@ID, @Title, @Quantity, @Price)";
            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@ID", book.BookID);
            cmd.Parameters.AddWithValue("@Title", book.BookTitle);
            cmd.Parameters.AddWithValue("@Quantity", book.BookQuantity);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return count > 0;
        }

        public bool UpdateBook(Book book)
        {
            SqlConnection con = new SqlConnection(strConnection);
            string SQL = "UPDATE Book SET BookTitle=@Title, BookQuantity=@Quantity, BookPrice=@Price WHERE BookID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@Title", book.BookTitle);
            cmd.Parameters.AddWithValue("@Quantity", book.BookQuantity);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            cmd.Parameters.AddWithValue("@ID", book.BookID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return count > 0;
        }

        public bool DeleteBook(int BookID)
        {
            SqlConnection con = new SqlConnection(strConnection);
            string SQL = "DELETE Book WHERE BookID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, con);
            cmd.Parameters.AddWithValue("@ID", BookID);
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return count > 0;
        }
    }
}
