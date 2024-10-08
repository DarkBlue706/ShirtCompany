using ShirtCompany.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ShirtCompany.Models.Repositories
{
    public static class ShirtRepository
    {
            private static List<Shirt> shirts = new List<Shirt>()
            {
                new Shirt { ProductID = 1, Brand = "MyBrand", Color = "Blue", Gender = "women", Price = 30, Size = 6},
                new Shirt { ProductID = 2, Brand = "MyBrand", Color = "Black", Gender = "Men", Price = 30, Size = 5},
                new Shirt { ProductID = 3, Brand = "YourBrand", Color = "Pink", Gender = "men", Price = 30, Size = 2},
                new Shirt { ProductID = 4, Brand = "YourBrand", Color = "Yellow", Gender = "Women", Price = 30, Size = 12},
            };

            public static List<Shirt> GetShirts()
            {
                return shirts;
            }

            public static bool ShirtExists(int id)
            {
                return shirts.Any(x=> x.ProductID == id);
            }
            public static Shirt? GetShirtById(int id)
            {
                return shirts.FirstOrDefault(X=> X.ProductID == id);
            }

            public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
            {
                return shirts.FirstOrDefault( x =>
                !string.IsNullOrWhiteSpace(brand)&&
                !string.IsNullOrWhiteSpace(x.Brand)&&
                x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&

                !string.IsNullOrWhiteSpace(gender)&&
                !string.IsNullOrWhiteSpace(x.Gender)&&
                x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&

                !string.IsNullOrWhiteSpace(color)&&
                !string.IsNullOrWhiteSpace(x.Color)&&
                x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&

                size.HasValue &&
                x.Size.HasValue &&
                size.Value == x.Size.Value); 
            }

            public static void AddShirt(Shirt shirt)
            {
                int maxId = shirts.Max(x => x.ProductID);
                shirt.ProductID = maxId + 1;

                shirts.Add(shirt);
            }

            public static void UpdateShirt(Shirt shirt)
            {
                var shirtToUpdate = shirts.First(x => x.ProductID == shirt.ProductID);
                shirtToUpdate.Brand = shirt.Brand;
                shirtToUpdate.Price = shirt.Price;
                shirtToUpdate.Size = shirt.Size;
                shirtToUpdate.Color = shirt.Color;
                shirtToUpdate.Gender = shirt.Gender;
            }

            public static void DeleteShirt(int shirtId)
            {
                var shirt = GetShirtById(shirtId);
                if (shirt != null)
                {
                    shirts.Remove(shirt);
                }
            }

    };
}