using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcudirET.BusinessLogic.Service.Interfaces
{
    public interface IGetterService<T>
    {
        List<T> GetAll();
        T GetById(int id);
    }
}