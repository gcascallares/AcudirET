using AcudirET.BusinessLogic.Service.Interfaces;
using AcudirET.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.BusinessLogic.Service
{
    public class MedioDePagoService : IMedioDePagoService
    {
        private readonly MedioDePagoRepository medioDePagoRepository;
        public MedioDePagoService()
        {
            this.medioDePagoRepository = new MedioDePagoRepository();
        }
        public void Delete(int id)
        {
            this.medioDePagoRepository.Delete(id);
        }

        public List<MedioDePago> GetAll()
        {
            return this.medioDePagoRepository.GetAll();
        }

        public MedioDePago GetById(int id)
        {
            return this.medioDePagoRepository.Get(id);
        }

        public int Insert(MedioDePago entity)
        {
            return this.medioDePagoRepository.Insert(entity);
        }

        public void Update(MedioDePago entity)
        {
            this.medioDePagoRepository.Update(entity);
        }
    }
}