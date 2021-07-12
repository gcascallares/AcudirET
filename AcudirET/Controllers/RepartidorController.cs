using AcudirET.BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcudirET.Controllers
{
    public class RepartidorController : Controller
    {
        private RepartidorService RepartidorService { get; set; }

        public RepartidorController()
        {
            this.RepartidorService = new RepartidorService();
        }

        [HttpGet]
        public ActionResult RepartidorManager(int id)
        {
            if (id == 0)
                return View(new Repartidor());

            Repartidor repartidor = this.RepartidorService.GetById(id);

            return View(repartidor);
        }

        [HttpPost]
        public ActionResult RepartidorManager(Repartidor repartidor)
        {
            try
            {
                if (repartidor.Id == 0)
                    this.RepartidorService.Insert(repartidor);
                else
                    this.RepartidorService.Update(repartidor);

                return RedirectToAction("RepartidorList", "Repartidor");
            }
            catch (Exception ex)
            {
                TempData["messageERROR"] = "Se produjo un error en la aplicación. " + ex.Message;

                return View("RepartidorManager", repartidor);
            }
        }
        public ActionResult RepartidorList()
        {
            List<Repartidor> repartidores = RepartidorService.GetAll();
            ViewBag.Repartidores = repartidores;
            return View();
        }
    }
}