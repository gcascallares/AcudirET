using AcudirET.BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcudirET.Controllers
{
    public class HomeController : Controller
    {
        private PedidoService PedidoService { get; set; }


        public HomeController()
        {
            this.PedidoService = new PedidoService();
        }
        public ActionResult Index()
        {
            List<Pedido> pedidos = PedidoService.GetAll();
            ViewBag.PedidosCancelados = pedidos.Where(x => x.EstadoPedido.Descripcion.Equals("Cancelado")).Count();
            ViewBag.PedidosEntregados = pedidos.Where(x => x.EstadoPedido.Descripcion.Equals("Entregado")).Count();
            ViewBag.PedidosEnPreparacion = pedidos.Where(x => x.EstadoPedido.Descripcion.Equals("En Preparacion")).Count();
            ViewBag.PedidosEnviados = pedidos.Where(x => x.EstadoPedido.Descripcion.Equals("Enviado")).Count();
            return View();
        }
    }
}