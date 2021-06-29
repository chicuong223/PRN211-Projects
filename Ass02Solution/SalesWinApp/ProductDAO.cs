using BusinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                }
                return instance;
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                List<Product> lst = context.Products.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product GetProductByID(int productID)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                Product pro = (from p in context.Products
                               where p.ProductId == productID
                               select p).Single();
                return pro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insert(Product product)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(Product product)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Product> GetProductsByName(string name)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                var query = from pro in context.Products.ToList()
                            where pro.ProductName.ToLower().Contains(name.ToLower())
                            select pro;
                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Product newProduct)
        {
            try
            {
                using FstoreContext context = new FstoreContext();
                context.Entry(newProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
