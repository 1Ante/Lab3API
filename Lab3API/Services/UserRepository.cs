using Lab3API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterest.Model;

namespace Lab3API.Services
{
    public class UserRepository : IUser<User>
    {
        private AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<User> Add(User newEntity)
        {
            var result = await _appDbContext.Users.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }      

        public async Task<User> Delete(int id)
        {
            var result = await _appDbContext.Users.
                FirstOrDefaultAsync(u => u.UserID == id);
            if ( result != null)
            {
                _appDbContext.Users.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return result;

        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetSingle(int id)
        {
            return await _appDbContext.Users.Include(u => u.UserInterests).ThenInclude(i => i.Interest).
            FirstOrDefaultAsync(i => i.UserID == id);

            //var result = from a in _appDbContext.Users
            //             join b in _appDbContext.UserInterests on a.UserID equals b.UserID
            //             where a.UserID == id && b.UserID == id
            //             join c in _appDbContext.Interests on b.InterestID equals c.InterestID
            //             select new { a.FirstName, a.LastName, c.Title, c.Description };

            //return (Task<User>)result;

        }

              

        public async Task<User> Update(User Entity)
        {
            var result = await _appDbContext.Users.
                FirstOrDefaultAsync(u => u.UserID == Entity.UserID);
            if (result != null)
            {
                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.Address = Entity.Address;
                result.Phone = Entity.Phone;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

       
    }
}
