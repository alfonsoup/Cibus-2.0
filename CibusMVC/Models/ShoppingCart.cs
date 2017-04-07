﻿
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CibusMVC.Models
{
    public partial class ShoppingCart
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";


        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }


        public void AddToCart(ComboRestaurante combo)
        {
            // Get the matching cart and album instances
            var cartItem = db.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.IdComboRestaurante == combo.IdComboRestaurante);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    IdComboRestaurante = combo.IdComboRestaurante,
                    CartId = ShoppingCartId,
                    Cantidad = 1,
                    FechaCreacion = DateTime.Now

                    //,RecordId = null
                };
                db.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Cantidad++;
            }



            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges


                // Save changes
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



            
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = db.Carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Cantidad > 1)
                {
                    cartItem.Cantidad--;
                    itemCount = cartItem.Cantidad;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }
                // Save changes
                db.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = db.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            // Save changes
            db.SaveChanges();
        }
        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.Carts
                          where cartItems.CartId == ShoppingCartId
                          select ( int?)cartItems.Cantidad).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in db.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Cantidad *
                              cartItems.ComboRestaurante.Precio).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Pedido order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new DetallePedido
                {
                    IdComboRestaurante = item.IdComboRestaurante,
                    IdPedido = order.IdPedido,
                    PrecioUnitario = item.ComboRestaurante.Precio,
                    Cantidad = item.Cantidad,
                  
                    
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Cantidad * item.ComboRestaurante.Precio);

                db.DetallePedidos.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
           // order.Total = orderTotal;
            var pedido1 = db.Pedidos.Find(order.IdPedido);
            pedido1.Total = orderTotal;

            // Save the order
            db.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.IdPedido;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Carts.Where(
                c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            db.SaveChanges();
        }
    }
}