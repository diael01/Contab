

using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Impl
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly ContabContext _context;

        public DiseaseRepository(ContabContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Disease>> GetAllAsync()
        {
            return await _context.Diseases.ToListAsync();
        }

        public async Task<Disease> GetByIdAsync(int id)
        {
            return await _context.Diseases.FindAsync(id);
        }

        public async Task AddAsync(Disease disease)
        {
            await _context.Diseases.AddAsync(disease);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Disease disease)
        {
            _context.Diseases.Update(disease);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
                await _context.SaveChangesAsync();
            }
        }
    }

}

