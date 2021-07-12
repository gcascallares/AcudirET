using AcudirET.BusinessLogic.Service.Interfaces;
using AcudirET.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.BusinessLogic.Service
{
    public class RepartidorService : IRepartidorService
    {
        private readonly RepartidorRepository repartidorRepository;
        public RepartidorService()
        {
            this.repartidorRepository = new RepartidorRepository();
        }
        public void Delete(int id)
        {
            this.repartidorRepository.Delete(id);
        }

        public List<Repartidor> GetAll()
        {
            return this.repartidorRepository.GetAll();
        }

        public Repartidor GetById(int id)
        {
            return this.repartidorRepository.Get(id);
        }

        public int Insert(Repartidor entity)
        {
            return this.repartidorRepository.Insert(entity);
        }

        public void Update(Repartidor entity)
        {
            this.repartidorRepository.Update(entity);
        }
    }
}