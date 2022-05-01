using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3API.Services
{
    public interface IUserInterest<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(int id);

        Task<T> Add(T newEntity);

        Task<T> Update(T Entity);

        Task<T> Delete(int id);
    }
}
