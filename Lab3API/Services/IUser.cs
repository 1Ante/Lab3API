using Lab3API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterest.Model;

namespace Lab3API.Services
{
    public interface IUser<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(int id);        

        Task<T> Add(T newEntity);

        Task<T> Update(T newEntity);

        Task<T> Delete(int id);

    }    
}
