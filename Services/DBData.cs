using ProductManagementSystem.Models;
using System.Collections.Generic;


namespace ProductManagementSystem.Services
{
    public class DBData : IProductRepository
    {
        public List<Product> Products { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        private ProductContext productContext;

        public DBData(ProductContext _productContext)
        {
            productContext = _productContext;
        }

        public void AddProduct(Product product)
        {
            productContext.Products.Add(product);
            productContext.SaveChanges();
        }

        public void DeleteProduct(int? id)
        {
            var pro = productContext.Products.Find(id);
                if (pro != null)
            {
                productContext.Products.Remove(pro);
                productContext.SaveChanges();
            }
        }

        public Product GetProduct(int? id)
        {
            return productContext.Products.Find(id);
        }

        public List<Product> ReadAll()
        {
            return new List<Product> (productContext.Products);
        }

        public void UpdateProduct(Product product)
        {
            var pro = productContext.Products.Find(product.Id);
            if (product != null)
            {
                pro.Id = product.Id;
                pro.Name = product.Name;
                pro.Description = product.Description;
                pro.Price = product.Price;
                pro.ImageName = product.ImageName;
            }
            productContext.SaveChanges();
        }
    }
}
