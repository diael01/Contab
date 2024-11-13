using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Impl
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly ContabContext _context;
        public DiseaseRepository(ContabContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Disease>> GetDiseases()
        {
            return await _context.Diseases.ToListAsync();
        }
        public async Task<Disease> GetDisease(int id)
        {
            return await _context.Diseases.FindAsync(id);
        }

        public async Task<Disease> AddDisease(Disease disease)
        {
            _context.Diseases.Add(disease);
            await _context.SaveChangesAsync();
            return disease;
        }

        public async Task<Disease> UpdateDisease(Disease disease)
        {
            _context.Entry(disease).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return disease;
        }

        public async Task<Disease> DeleteDisease(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
                await _context.SaveChangesAsync();
            }
            return disease;
        }
    }
}
