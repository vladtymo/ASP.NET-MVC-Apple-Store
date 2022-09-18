using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class SeedDataExtensions
    {
        public static void SeedPhones(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(new Phone[]
            {
                new Phone()
                {
                    Id = 1,
                    Model = "iPhone 14",
                    Color = "Midnight",
                    Memory = 128,
                    Price = 799,
                    Description = "A total powerhouse.",
                    ImagePath = @"https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-finish-select-202209-6-1inch-midnight_1.png"
                },
                new Phone()
                {
                    Id = 2,
                    Model = "iPhone 14 Plus",
                    Color = "Starlight",
                    Memory = 128,
                    Price = 899,
                    Description = "Big and bigger.",
                    ImagePath = @"https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/i/p/iphone-14-plus_2__3.jpeg"
                },
                new Phone()
                {
                    Id = 3,
                    Model = "iPhone 14 Pro",
                    Color = "Space Black",
                    Memory = 256,
                    Price = 1099,
                    Description = "The ultimate iPhone.",
                    ImagePath = @"https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-black-1_4_2.jpeg"
                },
                new Phone()
                {
                    Id = 4,
                    Model = "iPhone 14 Pro Max",
                    Color = "Deep Purple",
                    Memory = 512,
                    Price = 1399,
                    Description = "Pro. Beyond.",
                    ImagePath = @"https://estore.ua/ua/media/catalog/product/cache/9/image/600x600/9df78eab33525d08d6e5fb8d27136e95/1/4/14pro-promax-purple-1_9.jpeg"
                }
            });
        }
    }
}
