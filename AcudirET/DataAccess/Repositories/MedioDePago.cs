using AcudirET.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.DataAccess.Repositories
{
    public class MedioDePagoRepository : IMedioDePagoRepository<MedioDePago>
    {
        public void Delete(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                MedioDePago medioDePago = context.MedioDePagos.FirstOrDefault(a => a.Id == id);

                if (medioDePago != null)
                {
                    context.MedioDePagos.Remove(medioDePago);
                }
                context.SaveChanges();
            }
        }

        public MedioDePago Get(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                MedioDePago medioDePago = (from ctx in context.MedioDePagos
                                           where ctx.Id == id
                                       select ctx).FirstOrDefault();

                return medioDePago;
            }
        }

        public List<MedioDePago> GetAll()
        {
            using (var context = new AcudirEtEntities())
            {
                List<MedioDePago> medioDePago = (from ctx in context.MedioDePagos
                                                 select ctx).ToList();

                return medioDePago;
            }
        }

        public int Insert(MedioDePago entity)
        {
            using (var context = new AcudirEtEntities())
            {

                context.MedioDePagos.Add(entity);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public void Update(MedioDePago entity)
        {
            using (var context = new AcudirEtEntities())
            {
                MedioDePago medioDePago = (from ctx in context.MedioDePagos
                                           where ctx.Id == entity.Id
                                           select ctx).FirstOrDefault();
                if (medioDePago != null)
                {
                    medioDePago.Descripcion = entity.Descripcion;
                }

                context.SaveChanges();
            }
        }
    }
}