using DirectorDomain.Core.Entities;
using DirectorDomain.Core.Interfaces;
using DirectorDomain.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorDomain.Infrastructure.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly Parcial20240121200032Context _dbContext;

        public DirectorRepository(Parcial20240121200032Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Director>> GetAll()
        {
            return await _dbContext.Director.ToListAsync();
        }

        public async Task<bool> Insert(Director director)
        {
            await _dbContext.Director.AddAsync(director);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Director director)
        {
            _dbContext.Director.Update(director);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findDirector = await _dbContext
                .Director
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();

            if (findDirector == null) return false;

            _dbContext.Director.Remove(findDirector);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
