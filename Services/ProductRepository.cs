using ProductManagementSystem.Models;
using System.Collections.Generic;

namespace ProductManagementSystem.Services

{
    public class ProductRepository : IProductRepository
    {
        public List<Product> Products { get; set; }

        public ProductRepository()
        {
            Products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Bokuto",
                    Description = "Wooden Training Sword",
                    Price = 24.99M,
                    ImageName = "woodensword.jpg"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Rubber Sais",
                    Description = "Rubber Training Sais",
                    Price = 15.00M,
                    ImageName = "rubbersai.jpg"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Rubber Combat Knife",
                    Description = "Rubber Training Knife for Training",
                    Price = 14.99M,
                    ImageName = "rubberknife.jpg"
                },
                new Product()
                {
                    Id = 4,
                    Name = "Foam Nunchuks",
                    Description = "A Pair of Foam Nunchucks",
                    Price = 22.99M,
                    ImageName = "foamnunchucks.jpg"
                },
                new Product()
                {
                    Id = 5,
                    Name = "Punching Mitts",
                    Description = "Punching Mitts for Training",
                    Price = 33.99M,
                    ImageName = "punchingmitts.jpg"
                },






            };
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
           
        }

        public void DeleteProduct(int? id)
        {
            var pro = Products.Find(x => x.Id == id);
            if (pro != null)
                Products.Remove(pro);
        }

        public Product GetProduct(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return Products.Find(x => x.Id == id);
            }
        }

        public List<Product> ReadAll()
        {
            return Products;
        }

        public void UpdateProduct(Product product)
        {
            var pro = Products.Find( x => x.Id == product.Id);
            if(pro != null)
            {
                pro.Id = product.Id;
                pro.Name = product.Name;
                pro.Description = product.Description;
                pro.Price = product.Price;
                pro.ImageName = product.ImageName;
                
            }
        }
    }
}
