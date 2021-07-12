using AcudirET.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.DataAccess.Repositories
{
    public class PedidoRepository : IPedidoRepository<Pedido>
    {
        public void Delete(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                Pedido pedido = context.Pedidos.FirstOrDefault(a => a.Id == id);

                if (pedido != null)
                {
                    context.Pedidos.Remove(pedido);
                }
                context.SaveChanges();
            }
        }

        public Pedido Get(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                Pedido pedido = (from ctx in context.Pedidos
                                 .Include("Cliente")
                                       .Include("Producto")
                                       .Include("MedioDePago")
                                       .Include("Repartidor")
                                       .Include("EstadoPedido")
                                 where ctx.Id == id
                                           select ctx).FirstOrDefault();

                return pedido;
            }
        }

        public List<Pedido> GetAll()
        {
            using (var context = new AcudirEtEntities())
            {
                List<Pedido> pedido = (from ctx in context.Pedidos
                                       .Include("Cliente")
                                       .Include("Producto")
                                       .Include("MedioDePago")
                                       .Include("Repartidor")
                                       .Include("EstadoPedido")
                                       select ctx).ToList();

                return pedido;
            }
        }

        public int Insert(Pedido entity)
        {
            using (var context = new AcudirEtEntities())
            {
                ProductoRepository productoRepository = new ProductoRepository();
                Producto producto = productoRepository.Get(entity.ProductoId);
                entity.PrecioFinal = (entity.Cantidad * producto.Precio);
                context.Pedidos.Add(entity);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public void Update(Pedido entity)
        {
            using (var context = new AcudirEtEntities())
            {
                Pedido pedido = (from ctx in context.Pedidos
                                 .Include("Cliente")
                                       .Include("Producto")
                                       .Include("MedioDePago")
                                       .Include("Repartidor")
                                       .Include("EstadoPedido")
                                 where ctx.Id == entity.Id
                                         select ctx).FirstOrDefault();
                if (pedido != null)
                {
                    Cliente clienteNuevo = (from ctx in context.Clientes
                                     where ctx.Id == entity.ClienteId
                                     select ctx).FirstOrDefault();

                    Repartidor repartidorNuevo = (from ctx in context.Repartidores
                                            where ctx.Id == entity.RepartidorId
                                            select ctx).FirstOrDefault();

                    Producto productoNuevo = (from ctx in context.Productos
                                            where ctx.Id == entity.ProductoId
                                            select ctx).FirstOrDefault();

                    MedioDePago medioDePagoNuevo = (from ctx in context.MedioDePagos
                                            where ctx.Id == entity.MedioPagoId
                                            select ctx).FirstOrDefault();

                    EstadoPedido estadoPedidoNuevo = (from ctx in context.EstadoPedidos
                                            where ctx.Id == entity.EstadoId
                                            select ctx).FirstOrDefault();


                    pedido.Observacion = entity.Observacion;
                    pedido.PrecioFinal = entity.PrecioFinal;
                    pedido.Cliente = clienteNuevo;
                    pedido.Repartidor = repartidorNuevo;
                    pedido.MedioDePago = medioDePagoNuevo;
                    pedido.PrecioFinal = (entity.Cantidad* productoNuevo.Precio);
                    pedido.EstadoPedido = estadoPedidoNuevo;
                    pedido.Producto = productoNuevo;
                    pedido.Cantidad = entity.Cantidad;
                }

                context.SaveChanges();
            }
        }
    }
}