using Sample.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Service
{
   public interface IGenericService<T> where T:class
    {
       void Insert(T t);
       void Delete(int id);
       void Update(T t);
       T GetById(int id);
       IEnumerable<T> GetAll();

    }
}
