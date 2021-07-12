using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.BusinessLogic.Service.Interfaces
{
    public interface IBaseService<T> : IGetterService<T>
    {
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}