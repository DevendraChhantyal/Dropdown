using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Repository
{
   public interface IGenericRepository<T> where T:class
    {
       void Insert(T t);
       void Update(T t);
       void Delete(int id);
       T GetById(int id);
       IEnumerable<T> GetAll();

    }
}
