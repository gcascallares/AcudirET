using AcudirET.BusinessLogic.Service.Interfaces;
using AcudirET.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.BusinessLogic.Service
{
    public class ProductoService : IProductoService
    {
        private readonly ProductoRepository productoRepository;
        public ProductoService()
        {
            this.productoRepository = new ProductoRepository();
        }
        public void Delete(int id)
        {
            this.productoRepository.Delete(id);
        }

        public List<Producto> GetAll()
        {
            return this.productoRepository.GetAll();
        }

        public Producto GetById(int id)
        {
            return this.productoRepository.Get(id);
        }

        public int Insert(Producto entity)
        {
            return this.productoRepository.Insert(entity);
        }

        public void Update(Producto entity)
        {
            this.productoRepository.Update(entity);
        }
    }
}