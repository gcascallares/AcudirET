using AcudirET.BusinessLogic.Service.Interfaces;
using AcudirET.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.BusinessLogic.Service
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteRepository clienteRepository;
        public ClienteService()
        {
            this.clienteRepository = new ClienteRepository();
        }
        public void Delete(int id)
        {
            this.clienteRepository.Delete(id);
        }

        public List<Cliente> GetAll()
        {
            return this.clienteRepository.GetAll();
        }

        public Cliente GetById(int id)
        {
            return this.clienteRepository.Get(id);
        }

        public int Insert(Cliente entity)
        {
            return this.clienteRepository.Insert(entity);
        }

        public void Update(Cliente entity)
        {
            this.clienteRepository.Update(entity);
        }
    }
}