using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
   public interface IRepository <T>
    {

        T CreateEntity(T t);
        void DeleteEntity(int id);
        void UpdateEntity(T t);
        T ReadEntity(int id);
        List<T> ReadAllEntities();
    }
}
