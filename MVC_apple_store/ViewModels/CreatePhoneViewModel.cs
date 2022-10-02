using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_apple_store.ViewModels
{
    public class CreatePhoneViewModel
    {
        public Phone Phone { get; set; }
        public SelectList Colors { get; set; }
    }
}
