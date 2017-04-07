using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CibusMVC.Models;
using CibusMVC.DAL;
using CibusMVC.ViewModels;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace CibusMVC.Controllers
{
    [Authorize]
    public class PedidoController : Controller
    {
        private IPedidoRepository pedidoRepository;
        private IDetallePedidoRepository detallePedidoRepository;
        private IRestauranteRepository restauranteRepository;
        private IComboRestauranteRepository comboRestauranteRepository;

        public PedidoController()
        {
            this.pedidoRepository = new PedidoRepository(new ApplicationDbContext());
            this.detallePedidoRepository = new DetallePedidoRepository(new ApplicationDbContext());
            this.restauranteRepository = new RestauranteRepository(new ApplicationDbContext());
            this.comboRestauranteRepository = new ComboRestauranteRepository(new ApplicationDbContext());
        }
        //GET: Pedido
        //public ActionResult Index(int id)
        //{
        //    DetallePedidoViewModel dpv = new DetallePedidoViewModel();
        //    var pedidos = pedidoRepository.GetTodosPedidosByIdPedido(id);
        //    var detallesPedidos = detallePedidoRepository.GetTodosDetallesPedidosByIdPedido(id);
        //    dpv.PedidosAll = pedidos.ToList();
        //    dpv.DetallesPedidosAll = detallesPedidos.ToList();

        //    return View(dpv);
        //}
        public ActionResult Index()
        {
            string email = System.Web.HttpContext.Current.User.Identity.Name.ToString();

            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = userManager.FindByEmail(email);

            //user.IdRestaurante
            //var comboRestaurante = db.ComboRestaurantes.Include(c => c.Restaurante);
            if (user.IsAdmin)
            {
                return RedirectToAction("Index", "AdministradorRestaurante");
            }
            else
            {
                int IdRestaurante = int.Parse(User.Identity.GetIdRestaurante());
                //    var pedido = from Restaurante
                //                 join
                //                    Restaurante.Nombre, IdDetallePedido, DetallePedido.IdComboRestaurante,DetallePedido.IdPedido,
                //                    Cantidad,PrecioUnitario,ComboRestaurante.Nombre,Pedido.IdCliente,Pedido.Fecha, Pedido.Total
                //                    from Restaurante
                //                    INNER JOIN ComboRestaurante ON Restaurante.IdRestaurante = ComboRestaurante.IdRestaurante
                //                    INNER JOIN DetallePedido ON ComboRestaurante.IdComboRestaurante = DetallePedido.IdComboRestaurante
                //                    INNER JOIN Pedido ON Pedido.IdPedido = DetallePedido.IdPedido
                //                     where ComboRestaurante.IdRestaurante = 1

                //DetallePedidoViewModel dpv = new DetallePedidoViewModel();
                var pedidos = pedidoRepository.GetPedidos();
                var detallesPedidos = detallePedidoRepository.GetDetallePedidos();
                var restaurantes = restauranteRepository.GetRestaurantes();
                var comboRestaurante = comboRestauranteRepository.GetComboRestaurantes();
                //Algo algo = new Algo();
                IEnumerable<Algo> algo2 = (from a in restaurantes
                                           join b in comboRestaurante on a.IdRestaurante equals b.IdRestaurante
                                           join c in detallesPedidos on b.IdComboRestaurante equals c.IdComboRestaurante
                                           join d in pedidos on c.IdPedido equals d.IdPedido
                                           where b.IdRestaurante == IdRestaurante
                                           // group b.IdComboRestaurante by d.IdPedido
                                           select new Algo
                                           {
                                               ResName = a.Nombre,
                                               IdDetallePedido = c.IdDetallePedido,
                                               IdComboRestaurante = c.IdComboRestaurante,
                                               IdPedido = c.IdPedido,
                                               Cantidad = c.Cantidad,
                                               PrecioUnitario = c.PrecioUnitario,
                                               ComboResNombre = b.Nombre,
                                               IdCliente = d.IdCliente,
                                               Fecha = d.Fecha,
                                               Total = d.Total
                                           });
                DetallePedidoViewModel dpv = new DetallePedidoViewModel();
                dpv.AlgoAll = algo2.ToList();
                dpv.PedidosAll = pedidos.ToList();




                return View(dpv);
                //    from s in detallePedidoRepository.GetDetallePedidos() select s;
                //return View(pedido);
                //}

                //   public ActionResult AddPedido(int idComboRestaurante, )
                // {

                //}

            }
        }
    }
}