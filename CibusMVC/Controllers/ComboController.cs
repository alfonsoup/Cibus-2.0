using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CibusMVC.DAL;
using CibusMVC.Models;

namespace CibusMVC.Controllers
{
    public class ComboController : Controller
    {
        //private UnitOfWork unitOfWork = new UnitOfWork();
        private IComboRestauranteRepository comboRestauranteRepository;
        public ComboController()
        {
            this.comboRestauranteRepository = new ComboRestauranteRepository(new ApplicationDbContext());
        }

        public  ComboController(IComboRestauranteRepository comboRestauranteRepository)
        {
            this.comboRestauranteRepository = comboRestauranteRepository;
        }



        
        // GET: Combo
        public ActionResult Index(int id)
        {
            var combo = from s in comboRestauranteRepository.GetByIDRestaurante(id) select s;
            return View(combo);
        }
    }
}