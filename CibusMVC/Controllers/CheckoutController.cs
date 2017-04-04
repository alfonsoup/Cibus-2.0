using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CibusMVC.Models;
using CibusMVC.ViewModels;
using CibusMVC.DAL;

namespace CibusMVC.Controllers
{
    public class CheckoutController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Checkout/Confirmar
        public ActionResult Confirmar()
        {
            string ip =null ;
            var pedido = new Pedido();
            ip = HttpContext.Request.ServerVariables["REMOTE_ADDR"];

            ip=ip.Remove(0,7);
           
            pedido.IdCliente = ip; //HttpContext.Request.UserHostAddress;
            pedido.Fecha = DateTime.Now;

            db.Pedidos.Add(pedido);
            db.SaveChanges();

            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.CreateOrder(pedido);

            return RedirectToAction("Completado", new { id = pedido.IdPedido});

        }

        public ActionResult Completado(int id)
        {
            string ip = null;
            var pedido = new Pedido();
             ip = HttpContext.Request.ServerVariables["REMOTE_ADDR"];
            ip=ip.Remove(0, 7);
            // Validate customer owns this order
            bool isValid = db.Pedidos.Any(
                o => o.IdPedido == id &&
                o.IdCliente == ip);

            if (isValid)
            {
                var o = db.Pedidos.First(asd => asd.IdPedido == id);
                return View(o);
            }
            else
            {
                return View("Error");
            }
        }
    }
}