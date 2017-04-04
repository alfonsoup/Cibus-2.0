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
    public class CombosController : Controller
    {
        // GET: Combos

        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Restaurantes
        public ActionResult Menu(int id)
        {
            //var combos= unitOfWork.ComboRestauranteRepository.dbSet.
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}