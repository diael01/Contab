using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;


namespace Repository.Impl
{
    public class DiseaseCodeRepository : IDiseaseCodeRepository
    {
        private readonly ContabContext _context;

        public DiseaseCodeRepository(ContabContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiseaseCode>> GetAllAsync()
        {
            //return await _context.DiseaseCodes.ToListAsync();
            return await EfExtensions.ToListAsyncSafe<DiseaseCode>(_context.DiseaseCodes.AsQueryable());
        }

        public async Task<DiseaseCode> GetByIdAsync(int id)
        {
            return await _context.DiseaseCodes.FindAsync(id);
        }

        public async Task AddAsync(DiseaseCode diseaseCode)
        {
            await _context.DiseaseCodes.AddAsync(diseaseCode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DiseaseCode diseaseCode)
        {
            _context.DiseaseCodes.Update(diseaseCode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var diseaseCode = await _context.DiseaseCodes.FindAsync(id);
            if (diseaseCode != null)
            {
                _context.DiseaseCodes.Remove(diseaseCode);
                await _context.SaveChangesAsync();
            }
        }
    }

}
