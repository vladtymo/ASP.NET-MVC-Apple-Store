using DataAccess;
using DataAccess.Entities;
using MVC_apple_store.Helpers;

namespace MVC_apple_store.Services
{
    public interface ICartService
    {
        bool IsProductInCart(int id);
        void AddProductToCart(int id);
        void RemoveProductFromCart(int id);
        IEnumerable<Phone> GetProductsFromCart();
    }
    public class CartService : ICartService
    {
        private readonly StoreDbContext context;
        private readonly HttpContext httpContext;

        public CartService(StoreDbContext context,
                           IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContext = httpContextAccessor.HttpContext;
        }

        public bool IsProductInCart(int id)
        {
            var productIds = httpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null) return false;

            return productIds.Contains(id);
        }

        public void AddProductToCart(int id)
        {
            var productIds = httpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null)
                productIds = new List<int>();

            productIds.Add(id);

            httpContext.Session.SetObject(WebConstants.cartListKey, productIds);
        }
        public void RemoveProductFromCart(int id)
        {
            var productIds = httpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null) return;

            productIds.Remove(id);

            httpContext.Session.SetObject(WebConstants.cartListKey, productIds);
        }
        public IEnumerable<Phone> GetProductsFromCart()
        {
            var productIds = httpContext.Session.GetObject<List<int>>(WebConstants.cartListKey);

            if (productIds == null) return new List<Phone>();

            List<Phone> phones = productIds.Select(id => context.Phones.Find(id)).ToList();

            return phones;
        }
    }
}
