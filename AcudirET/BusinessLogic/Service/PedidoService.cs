using AcudirET.BusinessLogic.Service.Interfaces;
using AcudirET.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.BusinessLogic.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoRepository pedidoRepository;
        public PedidoService()
        {
            this.pedidoRepository = new PedidoRepository();
        }
        public void Delete(int id)
        {
            this.pedidoRepository.Delete(id);
        }

        public List<Pedido> GetAll()
        {
            return this.pedidoRepository.GetAll();
        }

        public Pedido GetById(int id)
        {
            return this.pedidoRepository.Get(id);
        }

        public int Insert(Pedido entity)
        {
            return this.pedidoRepository.Insert(entity);
        }

        public void Update(Pedido entity)
        {
            this.pedidoRepository.Update(entity);
        }
    }
}