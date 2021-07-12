using AcudirET.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.DataAccess.Repositories
{
    public class EstadoPedidoRepository : IEstadoPedidoRepository<EstadoPedido>
    {
        public void Delete(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                EstadoPedido estadoPedido = context.EstadoPedidos.FirstOrDefault(a => a.Id == id);

                if (estadoPedido != null)
                {
                    context.EstadoPedidos.Remove(estadoPedido);
                }
                context.SaveChanges();
            }
        }

        public EstadoPedido Get(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                EstadoPedido estadoPedido = (from ctx in context.EstadoPedidos
                                             where ctx.Id == id
                                       select ctx).FirstOrDefault();

                return estadoPedido;
            }
        }

        public List<EstadoPedido> GetAll()
        {
            using (var context = new AcudirEtEntities())
            {
                List<EstadoPedido> estadoPedido = (from ctx in context.EstadoPedidos
                                                   select ctx).ToList();

                return estadoPedido;
            }
        }

        public int Insert(EstadoPedido entity)
        {
            using (var context = new AcudirEtEntities())
            {

                context.EstadoPedidos.Add(entity);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public void Update(EstadoPedido entity)
        {
            using (var context = new AcudirEtEntities())
            {
                EstadoPedido estadoPedido = (from ctx in context.EstadoPedidos
                                             where ctx.Id == entity.Id
                                           select ctx).FirstOrDefault();
                if (estadoPedido != null)
                {
                    estadoPedido.Descripcion = entity.Descripcion;
                }

                context.SaveChanges();
            }
        }
    }
}