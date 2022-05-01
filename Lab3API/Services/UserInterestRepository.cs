using Lab3API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterest.Model;

namespace Lab3API.Services
{
    public class UserInterestRepository : IUserInterest<UserInterests>
    {
        private AppDbContext _appDbContext;

        public UserInterestRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<UserInterests> Add(UserInterests newEntity)
        {
            var result = await _appDbContext.UserInterests.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserInterests> Delete(int id)
        {
            var result = await _appDbContext.UserInterests.
                FirstOrDefaultAsync(u => u.UserInterestID == id);
            if (result != null)
            {
                _appDbContext.UserInterests.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<UserInterests>> GetAll()
        {
            return await _appDbContext.UserInterests.ToListAsync();
        }

        public async Task<UserInterests> GetSingle(int id)
        {
            return await _appDbContext.UserInterests.
                FirstOrDefaultAsync(u => u.UserInterestID == id);
        }

        public async Task<UserInterests> Update(UserInterests Entity)
        {
            var result = await _appDbContext.UserInterests.
                FirstOrDefaultAsync(o => o.UserInterestID == Entity.UserInterestID);
            if (result != null)
            {
                result.UserID = Entity.UserID;
                result.InterestID = Entity.InterestID;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;

        }
    }
}
