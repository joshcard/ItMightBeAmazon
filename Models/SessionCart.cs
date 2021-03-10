using System;
using System.Text.Json.Serialization;
using ItMightBeAmazon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ItMightBeAmazon.Infrastructure;
namespace ItMightBeAmazon.Models
{
    //SessionCart class that inherits from the Cart class
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }

        //override the AddItem method from the Cart class
        public override void AddItem(Book book, int quantity)
        {
            base.AddItem(book, quantity);
            Session.SetJson("Cart", this);
        }

        //override the RemoveLine method from the Cart class
        public override void RemoveLine(Book book)
        {
            base.RemoveLine(book);
            Session.SetJson("Cart", this);
        }

        //override the Clear method from the Cart class
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
