using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CibusMVC.Models;
using CibusMVC.DAL;

namespace CibusMVC.Controllers
{
    public class RestaurantesController : Controller
    {
      

        
        private IRestauranteRepository restauranteRepository;
        public RestaurantesController()
        {
            this.restauranteRepository = new RestauranteRepository(new ApplicationDbContext());
        }

        public  RestaurantesController(IRestauranteRepository restauranteRepository)
        {
            this.restauranteRepository = restauranteRepository;
        }


        // GET: Restaurantes
        public ActionResult Index(String tipo)
        {

            IEnumerable<Restaurante> restaurantes;


            if (String.IsNullOrEmpty(tipo))
            {
                restaurantes = from s in restauranteRepository.GetRestaurantes() select s;
            }
            else {
                restaurantes = from s in restauranteRepository.GetRestaurantesByTipo(tipo) select s;

            }

           
            return View(restaurantes);
        }
        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}

    


    }
}
