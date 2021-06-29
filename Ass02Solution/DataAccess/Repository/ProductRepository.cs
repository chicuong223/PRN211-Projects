using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product)
        {
            ProductDAO.Instance.Delete(product);
        }

        public Product GetProductByID(int productID)
        {
            return ProductDAO.Instance.GetProductByID(productID);
        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductDAO.Instance.GetAll();
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return ProductDAO.Instance.GetProductsByName(name);
        }

        public void InsertProduct(Product product)
        {
            ProductDAO.Instance.Insert(product);
        }

        public void UpdateProduct(Product newProduct)
        {
            ProductDAO.Instance.Update(newProduct);
        }
    }
}
