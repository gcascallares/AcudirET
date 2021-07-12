using AcudirET.BusinessLogic.Service.Interfaces;
using AcudirET.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.BusinessLogic.Service
{
    public class EstadoPedidoService : IEstadoPedidoService
    {
        private readonly EstadoPedidoRepository estadoPedidoRepository;
        public EstadoPedidoService()
        {
            this.estadoPedidoRepository = new EstadoPedidoRepository();
        }
        public void Delete(int id)
        {
            this.estadoPedidoRepository.Delete(id);
        }

        public List<EstadoPedido> GetAll()
        {
            return this.estadoPedidoRepository.GetAll();
        }

        public EstadoPedido GetById(int id)
        {
            return this.estadoPedidoRepository.Get(id);
        }

        public int Insert(EstadoPedido entity)
        {
            return this.estadoPedidoRepository.Insert(entity);
        }

        public void Update(EstadoPedido entity)
        {
            this.estadoPedidoRepository.Update(entity);
        }
    }
}