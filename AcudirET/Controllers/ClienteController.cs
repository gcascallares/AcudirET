using AcudirET.BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcudirET.Controllers
{
    public class ClienteController : Controller
    {

        private ClienteService ClienteService { get; set; }

        public ClienteController()
        {
            this.ClienteService = new ClienteService();
        }

        [HttpGet]
        public ActionResult ClienteManager(int id)
        {
            if (id == 0)
                return View(new Cliente());

            Cliente cliente = this.ClienteService.GetById(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult ClienteManager(Cliente cliente)
        {
            try
            {
                if (cliente.Id == 0)
                    this.ClienteService.Insert(cliente);
                else
                    this.ClienteService.Update(cliente);

                return RedirectToAction("ClienteList", "Cliente");
            }
            catch (Exception ex)
            {
                TempData["messageERROR"] = "Se produjo un error en la aplicación. " + ex.Message;

                return View("ClienteManager", cliente);
            }
        }
        public ActionResult ClienteList()
        {
            List<Cliente> clientes = ClienteService.GetAll();
            ViewBag.Clientes = clientes;
            return View();
        }
    }
}