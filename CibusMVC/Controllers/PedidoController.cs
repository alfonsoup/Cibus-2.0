using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CibusMVC.Models;
using CibusMVC.DAL;
using CibusMVC.ViewModels;
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


                IEnumerable<PedidoId> idPedido = (from a in restaurantes
                                                  join b in comboRestaurante on a.IdRestaurante equals b.IdRestaurante
                                                  join c in detallesPedidos on b.IdComboRestaurante equals c.IdComboRestaurante
                                                  join d in pedidos on c.IdPedido equals d.IdPedido
                                                  where b.IdRestaurante == IdRestaurante
                                                  select new PedidoId
                                                  {
                                                      IdCliente = d.IdCliente,
                                                      Fecha = d.Fecha,
                                                      idPedido = c.IdPedido
                                                  });
                //idPedido.ToList();
                //int var1 = 0, var2 = 0,ind=0;
                //List<PedidoId> id = new List<PedidoId>(5);
                
                //if (idPedido.Count() > 1)
                //{
                //    for (int i = 0; i < idPedido.Count(); i++)
                //    {
                //        if ((i + 1) < idPedido.Count()) { 
                //        var1 = System.Convert.ToInt32(idPedido.ElementAt(i).idPedido);
                //        var2 = System.Convert.ToInt32(idPedido.ElementAt(i + 1).idPedido);
                //        if ((i + 1) > idPedido.Count())
                //        {
                //            id.Add(idPedido.ElementAt(ind));
                //            id.ElementAt(ind).idPedido = (var1);
                //            id.ElementAt(ind).IdCliente = (idPedido.ElementAt(i).IdCliente);
                //            id.ElementAt(ind).Fecha = idPedido.ElementAt(i).Fecha;
                //            ind++;

                //            break;
                //        }
                //        else if (var1.Equals(var2))
                //        {

                //        }
                //        else
                //        {
                //            id.Add(idPedido.ElementAt(ind));
                //            id.ElementAt(ind).idPedido = (var1);
                //            id.ElementAt(ind).IdCliente = idPedido.ElementAt(i).IdCliente;
                //            id.ElementAt(ind).Fecha = idPedido.ElementAt(i).Fecha;
                //            ind++;
                //        }
                //    }
                //    }
                //    id.Add(idPedido.ElementAt(ind));
                //    id.ElementAt(ind).idPedido = var1;

                //}

                //id.ToList();
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

                //algo2 = algo2.ToList();
                //idPedido = idPedido.ToList();


                DetallePedidoViewModel dpv = new DetallePedidoViewModel();
                dpv.AlgoAll = algo2.ToList();
                dpv.PedidosAll = idPedido.ToList();
                //dpv.PedidosAll = id.ToList();
                //dpv.PedidosAll = pedidos.ToList();




                return View(dpv);
                //List<Algo> pedidoRest = new List<Algo>();
               
                //int indice = 0;
                ////int ind=0;
                ////pedidoRest.Capacity = algo2.Count();
                //decimal? TotalPedido = 0;
                //int flag = 0;
                //int cant=0;

                //foreach (Algo id in algo2)
                //{
                //   pedidoRest.Add(id);
                    
                //    foreach (Algo pedido in algo2)
                //    {
                //        if (pedido.IdPedido.Equals(id.IdPedido))
                //        {
                                
                //                pedidoRest.ElementAt(indice).nombreCombo.Add(pedido.ComboResNombre);
                //                pedidoRest.ElementAt(indice).cantidad.Add(pedido.Cantidad);
                //                pedidoRest.ElementAt(indice).precioUnitario.Add(pedido.PrecioUnitario);
                //                pedidoRest.ElementAt(indice).precioTotal.Add(pedido.PrecioUnitario * pedido.Cantidad);
                //                TotalPedido += (pedido.PrecioUnitario * pedido.Cantidad);
                               
                            
                            
                //        }
                        
                //    }

                //    pedidoRest.ElementAt(indice).IdCliente = id.IdCliente;
                //    pedidoRest.ElementAt(indice).Fecha = id.Fecha;
                //    pedidoRest.ElementAt(indice).TotalPedido = TotalPedido;
                //    indice++;
                   
                //    TotalPedido = 0;
                
                //}


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