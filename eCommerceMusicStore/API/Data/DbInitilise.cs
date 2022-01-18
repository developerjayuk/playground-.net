using System.Collections.Generic;
using System.Linq;
using API.Entities;

namespace API.Data
{
    public static class DbInitilize
    {
        public static void Initialize(StoreContext context)
        {
            if (context.Products.Any()) return;

            var products = new List<Product>{
                // guitars
                new Product
                {
                    Name = "Fender Stratocaster",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/guitar-fender-stratocaster.png",
                    Brand = "Fender",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Gibson Les Paul",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 15000,
                    PictureUrl = "/images/products/guitar-gibson-les-paul.png",
                    Brand = "Gibson",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Fender Telecaster",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/guitar-fender-telecaster.png",
                    Brand = "Fender",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "PRS Custom 24",
                    Description =
                        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 30000,
                    PictureUrl = "/images/products/guitar-prs-custom24.png",
                    Brand = "PRS",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Gibson SG",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 25000,
                    PictureUrl = "/images/products/guitar-gibson-sg.png",
                    Brand = "Gibson",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Rickenbacker 360",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 12000,
                    PictureUrl = "/images/products/guitar-rickenbacker-360.png",
                    Brand = "Rickenbacker",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Epiphone Casino",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1000,
                    PictureUrl = "/images/products/guitar-epiphone-casino.png",
                    Brand = "Epiphone",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Gibson Flying V",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 8000,
                    PictureUrl = "/images/products/guitar-gibson-flyingv.png",
                    Brand = "Gibson",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Ibanez Destroyer",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1500,
                    PictureUrl = "/images/products/guitar-ibanez-destroyer.png",
                    Brand = "Ibanez",
                    Type = "Guitar",
                    QuantityInStock = 100
                },
                 
                // keyboards
                new Product
                {
                    Name = "Korg Pa700 Electronic Keyboard",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1500,
                    PictureUrl = "/images/products/keyboard-korg-pa700.png",
                    Brand = "Korg",
                    Type = "Keyboard",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Casio CT-X700 Electronic Keyboard",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1600,
                    PictureUrl = "/images/products/keyboard-casio-ctx7000.png",
                    Brand = "Casio",
                    Type = "Keyboard",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Korg EK-50L Electronic Keyboard",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1400,
                    PictureUrl = "/images/products/keyboard-korg-ek50l.png",
                    Brand = "Korg",
                    Type = "Keyboard",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Roland GO:KEYS",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 25000,
                    PictureUrl = "/images/products/keyboard-roland-gokeys.png",
                    Brand = "Roland",
                    Type = "Keyboard",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Yamaha Genos",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 18999,
                    PictureUrl = "/images/products/keyboard-yamaha-genos.png",
                    Brand = "Yamaha",
                    Type = "Keyboard",
                    QuantityInStock = 100
                }
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}