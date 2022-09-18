using MVC_apple_store.Models;

namespace MVC_apple_store.Data
{
    public static class MockData
    {
        public static IEnumerable<Phone> GetPhones()
        {
            return new Phone[]
            {
                new Phone()
                {
                    Id = 1,
                    Model = "iPhone 14",
                    Color = "Black",
                    Memory = 128,
                    Price = 799,
                    Description = "A total powerhouse."
                },
                new Phone()
                {
                    Id = 2,
                    Model = "iPhone 14 Plus",
                    Color = "White",
                    Memory = 128,
                    Price = 899,
                    Description = "Big and bigger."
                },
                new Phone()
                {
                    Id = 3,
                    Model = "iPhone 14 Pro",
                    Color = "Space Black",
                    Memory = 256,
                    Price = 1099,
                    Description = "The ultimate iPhone."
                },
                new Phone()
                {
                    Id = 4,
                    Model = "iPhone 14 Pro Max",
                    Color = "Deep Purple",
                    Memory = 512,
                    Price = 1399,
                    Description = "Pro. Beyond."
                }
            };
        }
    }
}
