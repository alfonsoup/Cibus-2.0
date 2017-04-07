using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CibusMVC;
using CibusMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CibusMVC.Controllers
{

    [Authorize]
    public class AdministradorComboRestaurantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: AdministradorComboRestaurantes
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
            var comboRestaurante = db.ComboRestaurantes.Where(c => c.IdRestaurante == user.IdRestaurante);
            return View(comboRestaurante.ToList());
            }
        }

        // GET: AdministradorComboRestaurantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComboRestaurante comboRestaurante = db.ComboRestaurantes.Find(id);
            if (comboRestaurante == null)
            {
                return HttpNotFound();
            }
            return View(comboRestaurante);
        }

        // GET: AdministradorComboRestaurantes/Create
        public ActionResult Create()
        {
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "IdRestaurante", "Nombre");
            return View();
        }

        // POST: AdministradorComboRestaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComboRestaurante,IdRestaurante,Nombre,Descripcion,Precio,Imagen")] ComboRestaurante comboRestaurante)
        {
            if (ModelState.IsValid)
            {
                db.ComboRestaurantes.Add(comboRestaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "IdRestaurante", "Nombre", comboRestaurante.IdRestaurante);
            return View(comboRestaurante);
        }

        // GET: AdministradorComboRestaurantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComboRestaurante comboRestaurante = db.ComboRestaurantes.Find(id);
            if (comboRestaurante == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "IdRestaurante", "Nombre", comboRestaurante.IdRestaurante);
            return View(comboRestaurante);
        }

        // POST: AdministradorComboRestaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComboRestaurante,IdRestaurante,Nombre,Descripcion,Precio,Imagen")] ComboRestaurante comboRestaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comboRestaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "IdRestaurante", "Nombre", comboRestaurante.IdRestaurante);
            return View(comboRestaurante);
        }

        // GET: AdministradorComboRestaurantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComboRestaurante comboRestaurante = db.ComboRestaurantes.Find(id);
            if (comboRestaurante == null)
            {
                return HttpNotFound();
            }
            return View(comboRestaurante);
        }

        // POST: AdministradorComboRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComboRestaurante comboRestaurante = db.ComboRestaurantes.Find(id);
            db.ComboRestaurantes.Remove(comboRestaurante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
