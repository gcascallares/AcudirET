using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.DataAccess.Repositories
{
    public interface IGetterRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
    }
}