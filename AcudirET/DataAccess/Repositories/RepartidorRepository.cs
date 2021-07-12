using AcudirET.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.DataAccess.Repositories
{
    public class RepartidorRepository : IRepartidorRepository<Repartidor>
    {
        public void Delete(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                Repartidor repartidores = context.Repartidores.FirstOrDefault(a => a.Id == id);

                if (repartidores != null)
                {
                    context.Repartidores.Remove(repartidores);
                }
                context.SaveChanges();
            }
        }

        public Repartidor Get(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                Repartidor repartidores = (from ctx in context.Repartidores
                                   where ctx.Id == id
                                   select ctx).FirstOrDefault();

                return repartidores;
            }
        }

        public List<Repartidor> GetAll()
        {
            using (var context = new AcudirEtEntities())
            {
                List<Repartidor> repartidores = (from ctx in context.Repartidores
                                            select ctx).ToList();

                return repartidores;
            }
        }

        public int Insert(Repartidor entity)
        {
            using (var context = new AcudirEtEntities())
            {

                context.Repartidores.Add(entity);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public void Update(Repartidor entity)
        {
            using (var context = new AcudirEtEntities())
            {
                Repartidor repartidor = (from ctx in context.Repartidores
                                         where ctx.Id == entity.Id
                                   select ctx).FirstOrDefault();
                if (repartidor != null)
                {
                    repartidor.Nombre = entity.Nombre;
                }

                context.SaveChanges();
            }
        }
    }
}