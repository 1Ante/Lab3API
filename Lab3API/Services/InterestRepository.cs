using Lab3API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterest.Model;

namespace Lab3API.Services
{
    public class InterestRepository : IInterest<Interest>
    {
        private AppDbContext _appDbContext;

        public InterestRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _appDbContext.Interests.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }
 

        public async Task<Interest> Delete(int id)
        {
            var result = await _appDbContext.Interests.
                FirstOrDefaultAsync(i => i.InterestID == id);
            if (result != null)
            {
                _appDbContext.Interests.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appDbContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetSingle(int id)
        {
            return await _appDbContext.Interests.Include(i => i.UserInterests).
            FirstOrDefaultAsync(i => i.InterestID == id);
        }

        
        public async Task<Interest> Update(Interest Entity)
        {
            var result = await _appDbContext.Interests.
                FirstOrDefaultAsync(i => i.InterestID == Entity.InterestID);
            if (result != null)
            {
                result.Title = Entity.Title;
                result.Description = Entity.Description;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        
    }
}
