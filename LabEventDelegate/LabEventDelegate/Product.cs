using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LabEventDelegate
{
    public delegate void WarningDelegate(string message);
    class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Subtotal {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }

    class ManageProduct
    {
        //khai bao event dung de xuat thong-bao
        //sau khi product da bi xoa
        public event WarningDelegate EventAddProduct;
        //danh-sach de luu cac mat hang
        private ArrayList ProductList = new ArrayList();
        //khai bao property de lay danh sach mat hang
        public ArrayList GetProductList
        {
            get
            {
                return ProductList;
            }
        }
        //khai bao phuong-thuc tim product theo productID
        public Product Find(int ProductId)
        {
            foreach (Product p in ProductList)
            {
                if (p.ProductID == ProductId)
                    return p;

            }
            return null;
        }
        //khai bao phuong-thuc them product
        public void AddNew(Product p)
        {
            ProductList.Add(p);
        }
        //khai bao phuong-thuc xoa product
        public void Remove(int ProductID)
        {
            Product p = Find(ProductID);
            if(p != null)
            {
                ProductList.Remove(p);
                EventAddProduct("Product ID = " + p.ProductID + " removed successfully");
            }
        }
    }
}
