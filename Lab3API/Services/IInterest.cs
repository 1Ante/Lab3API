using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterest.Model;

namespace Lab3API.Services
{
    public interface IInterest<T>
    {
        
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(int id);

        Task<T> Add(T newEntity);

        Task<T> Update(T Entity);

        Task<T> Delete(int id);

    }
}
