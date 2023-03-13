using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission9_rcroft1_2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission9_rcroft1_2.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }


        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book Book1, int qty)
        {
            base.AddItem(Book1, qty);
            Session.SetJson("Basket", this);
        }
        public override void RemoveItem(Book book1)
        {
            base.RemoveItem(book1);
            Session.SetJson("Basket", this);
        }
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
