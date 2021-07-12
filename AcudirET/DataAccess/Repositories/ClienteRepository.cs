using AcudirET.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.DataAccess.Repositories
{
    public class ClienteRepository : IClienteRepository<Cliente>
    {
        public void Delete(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                Cliente cliente = context.Clientes.FirstOrDefault(a => a.Id == id);

                if (cliente != null)
                {
                    context.Clientes.Remove(cliente);
                }
                context.SaveChanges();
            }
        }

        public Cliente Get(int id)
        {
            using (var context = new AcudirEtEntities())
            {
                Cliente cliente = (from ctx in context.Clientes
                                       where ctx.Id == id
                                       select ctx).FirstOrDefault();

                return cliente;
            }
        }

        public List<Cliente> GetAll()
        {
            using (var context = new AcudirEtEntities())
            {
                List<Cliente> cliente = (from ctx in context.Clientes
                                                 select ctx).ToList();

                return cliente;
            }
        }

        public int Insert(Cliente entity)
        {
            using (var context = new AcudirEtEntities())
            {

                context.Clientes.Add(entity);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public void Update(Cliente entity)
        {
            using (var context = new AcudirEtEntities())
            {
                Cliente cliente = (from ctx in context.Clientes
                                           where ctx.Id == entity.Id
                                           select ctx).FirstOrDefault();
                if (cliente != null)
                {
                    cliente.Nombre = entity.Nombre;
                    cliente.Domicilio = entity.Domicilio;
                }

                context.SaveChanges();
            }
        }
    }
}