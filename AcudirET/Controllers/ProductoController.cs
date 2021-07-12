using AcudirET.BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcudirET.Controllers
{
    public class ProductoController : Controller
    {
        private ProductoService ProductoService { get; set; }

        public ProductoController()
        {
            this.ProductoService = new ProductoService();
        }

        [HttpGet]
        public ActionResult ProductoManager(int id)
        {
            if (id == 0)
                return View(new Producto());

            Producto producto = this.ProductoService.GetById(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult ProductoManager(Producto producto)
        {
            try
            {
                if (producto.Id == 0)
                    this.ProductoService.Insert(producto);
                else
                    this.ProductoService.Update(producto);

                return RedirectToAction("ProductoList", "Producto");
            }
            catch (Exception ex)
            {
                TempData["messageERROR"] = "Se produjo un error en la aplicación. " + ex.Message;

                return View("ProductoManager", producto);
            }
        }
        public ActionResult ProductoList()
        {
            List<Producto> producto = ProductoService.GetAll();
            ViewBag.Productos = producto;
            return View();
        }
    }
}