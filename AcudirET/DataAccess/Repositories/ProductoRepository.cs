using AcudirET.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.DataAccess.Repositories
{
    public class ProductoRepository : IProductoRepository<Producto>
    {
        public void Delete(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                Producto productos = context.Productos.FirstOrDefault(a => a.Id == id);

                if (productos != null)
                {
                    context.Productos.Remove(productos);
                }
                context.SaveChanges();
            }
        }

        public Producto Get(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                Producto productos = (from ctx in context.Productos
                                    where ctx.Id == id
                                       select ctx).FirstOrDefault();

                return productos;
            }
        }

        public List<Producto> GetAll()
        {
            using (var context = new AcudirEtEntities())
            {
                List<Producto> productos = (from ctx in context.Productos
                                          select ctx).ToList();

                return productos;
            }
        }

        public int Insert(Producto entity)
        {
            using (var context = new AcudirEtEntities())
            {

                context.Productos.Add(entity);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public void Update(Producto entity)
        {
            using (var context = new AcudirEtEntities())
            {
                Producto productos = (from ctx in context.Productos
                                    where ctx.Id == entity.Id
                                           select ctx).FirstOrDefault();
                if (productos != null)
                {
                    productos.Descripcion = entity.Descripcion;
                    productos.Precio = entity.Precio;
                }

                context.SaveChanges();
            }
        }
    }
}