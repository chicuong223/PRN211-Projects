using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void InsertProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProductByID(int productID);
        IEnumerable<Product> GetProductsByName(string name);
        void UpdateProduct(Product newProduct);
    }
}
