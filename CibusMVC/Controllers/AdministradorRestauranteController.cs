using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CibusMVC.DAL;
using System.Data.Entity;
using System.Net;
using CibusMVC.Models;

namespace CibusMVC.Controllers
{
    [Authorize]
    public class AdministradorRestauranteController : Controller
    {


        // GET: AdministradorRestaurante
        public ActionResult Index()
        {
            IEnumerable<Restaurante> restaurante = restauranteRepository.GetRestaurantes();
            return View(restaurante);
        }

        ApplicationDbContext db = new ApplicationDbContext();

        private IRestauranteRepository restauranteRepository;
        public AdministradorRestauranteController()
        {
            this.restauranteRepository = new RestauranteRepository(new ApplicationDbContext());
        }

        public  AdministradorRestauranteController(IRestauranteRepository restauranteRepository)
        {
            this.restauranteRepository = restauranteRepository;
        }
     

        // GET: Restaurantes/Details/5
        public ActionResult DetailsRestaurante(int id)
        {
            Restaurante restaurante;
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            restaurante = restauranteRepository.GetRestauranteByID(id);
            //Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Create
        public ActionResult CreateRestaurante()
        {
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurante([Bind(Include = "IdRestaurante,Nombre,Telefono,Logo,Tipo")] Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                restauranteRepository.InsertRestaurante(restaurante);
                restauranteRepository.Save();
                //db.Restaurantes.Add(restaurante);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Edit/5
        public ActionResult EditRestaurante(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            Restaurante restaurante = restauranteRepository.GetRestauranteByID(id);//db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRestaurante([Bind(Include = "IdRestaurante,Nombre,Telefono,Logo,Tipo")] Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {

                db.Entry(restaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Delete/5
        public ActionResult DeleteRestaurante(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("DeleteRestaurante")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedRestaurante(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            db.Restaurantes.Remove(restaurante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}