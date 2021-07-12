using AcudirET.BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcudirET.Controllers
{
    public class PedidoController : Controller
    {
        private PedidoService PedidoService { get; set; }
        private ClienteService ClienteService { get; set; }
        private RepartidorService RepartidorService { get; set; }
        private MedioDePagoService MedioDePagoService { get; set; }
        private EstadoPedidoService EstadoPedidoService { get; set; }
        private ProductoService ProductoService { get; set; }


        public PedidoController()
        {
            this.PedidoService = new PedidoService();
            this.ClienteService = new ClienteService();
            this.RepartidorService = new RepartidorService();
            this.MedioDePagoService = new MedioDePagoService();
            this.EstadoPedidoService = new EstadoPedidoService();
            this.ProductoService = new ProductoService();
        }

        [HttpGet]
        public ActionResult PedidoManager(int id)
        {

            if (id == 0)
            {
                ViewBag.EstadoPedido = this.GetAllEstadoPedido(0);
                ViewBag.Producto = this.GetAllProducto(0);
                ViewBag.MedioDePago = this.GetAllMedioDePago(0);
                ViewBag.Cliente = this.GetAllClientes(0);
                ViewBag.Repartidor = this.GetAllRepartidores(0);
                return View(new Pedido());
            }
            Pedido pedidos = this.PedidoService.GetById(id);
            ViewBag.EstadoPedido = this.GetAllEstadoPedido(Convert.ToInt32(pedidos.EstadoId));
            ViewBag.Producto = this.GetAllProducto(Convert.ToInt32(pedidos.Producto.Id));
            ViewBag.MedioDePago = this.GetAllMedioDePago(Convert.ToInt32(pedidos.MedioDePago.Id));
            ViewBag.Cliente = this.GetAllClientes(Convert.ToInt32(pedidos.Cliente.Id));
            ViewBag.Repartidor = this.GetAllRepartidores(Convert.ToInt32(pedidos.Repartidor.Id));
            return View(pedidos);
        }

        [HttpPost]
        public ActionResult PedidoManager(Pedido pedidos)
        {
            try
            {
                if (pedidos.Id == 0)
                    this.PedidoService.Insert(pedidos);
                else
                    this.PedidoService.Update(pedidos);

                return RedirectToAction("PedidoList", "Pedido");
            }
            catch (Exception ex)
            {
                TempData["messageERROR"] = "Se produjo un error en la aplicación. " + ex.Message;

                return View("PedidoManager", pedidos);
            }
        }
        public ActionResult PedidoList()
        {
            List<Pedido> pedidos = PedidoService.GetAll();
            ViewBag.Pedidos = pedidos;
            return View();
        }
        public ActionResult DeletePedido(int id)
        {
                try
                {
                    this.PedidoService.Delete(id);

                    return RedirectToAction("PedidoList", "Pedido");
                }
                catch (Exception ex)
                {
                    TempData["messageERROR"] = "Se produjo un error en la aplicación. " + ex.Message;

                    return Json(new { errorMessage = ex.Message });
                }
        }
        private IEnumerable<SelectListItem> GetAllClientes(int idCliente)
        {
            IEnumerable<Cliente> clientes = this.ClienteService.GetAll();

            IEnumerable<SelectListItem> items = clientes.ToList()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nombre,
                    Selected = (c.Id == idCliente)
                });
            return items;
        }
        private IEnumerable<SelectListItem> GetAllRepartidores(int idRepartidor)
        {
            IEnumerable<Repartidor> repartidores = this.RepartidorService.GetAll();

            IEnumerable<SelectListItem> items = repartidores.ToList()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nombre,
                    Selected = (c.Id == idRepartidor)
                });
            return items;
        }
        private IEnumerable<SelectListItem> GetAllMedioDePago(int idMedioDePago)
        {
            IEnumerable<MedioDePago> medioDePago = this.MedioDePagoService.GetAll();

            IEnumerable<SelectListItem> items = medioDePago.ToList()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Descripcion,
                    Selected = (c.Id == idMedioDePago)
                });
            return items;
        }
        private IEnumerable<SelectListItem> GetAllEstadoPedido(int idEstadoPedido)
        {
            IEnumerable<EstadoPedido> estadoPedido = this.EstadoPedidoService.GetAll();

            IEnumerable<SelectListItem> items = estadoPedido.ToList()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Descripcion,
                    Selected = (c.Id == idEstadoPedido)
                });
            return items;
        }
        private IEnumerable<SelectListItem> GetAllProducto(int idProducto)
        {
            IEnumerable<Producto> producto = this.ProductoService.GetAll();

            IEnumerable<SelectListItem> items = producto.ToList()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Descripcion,
                    Selected = (c.Id == idProducto)
                });
            return items;
        }
    }
}
