using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CibusMVC.DAL;
using CibusMVC.Models;

namespace CibusMVC.Controllers
{
    public class AdministradorUsuarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        //private IUsuarioRepository usuarioRepository;
        //public AdministradorUsuarioController()
        //{
        //    this.usuarioRepository = new UsuarioRepository(new CibusDB2Entities());
        //}

        //public  AdministradorUsuarioController(IUsuarioRepository usuarioRepository)
        //{
        //    this.usuarioRepository = usuarioRepository;
        //}

        //// GET: AdministradorUsuario
        //public ActionResult Index()
        //{
        //    IEnumerable<Usuario> usuario = usuarioRepository.GetUsuarios();
        //    return View(usuario);
        //}

        //// GET: AdministradorUsuario/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Usuario usuario = db.Usuarios.Find(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}

        //// GET: AdministradorUsuario/Create
        //public ActionResult Create()
        //{
        //    ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "IdRestaurante", "Nombre");
        //    return View();
        //}

        //// POST: AdministradorUsuario/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IdUsuario,Nombre,Password,IdRestaurante,IsAdmin")] Usuario usuario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Usuarios.Add(usuario);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "IdRestaurante", "Nombre", usuario.IdRestaurante);
        //    return View(usuario);
        //}

        //// GET: AdministradorUsuario/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Usuario usuario = db.Usuarios.Find(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "IdRestaurante", "Nombre", usuario.IdRestaurante);
        //    return View(usuario);
        //}

        //// POST: AdministradorUsuario/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IdUsuario,Nombre,Password,IdRestaurante,IsAdmin")] Usuario usuario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(usuario).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "IdRestaurante", "Nombre", usuario.IdRestaurante);
        //    return View(usuario);
        //}

        //// GET: AdministradorUsuario/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Usuario usuario = db.Usuarios.Find(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}

        //// POST: AdministradorUsuario/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Usuario usuario = db.Usuarios.Find(id);
        //    db.Usuarios.Remove(usuario);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
