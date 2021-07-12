using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.DataAccess.Repositories
{
    public interface IBaseRepository<T> : IGetterRepository<T>
    {
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}