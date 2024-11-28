using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Impl
{
    public class DiseaseCodeRepository : IDiseaseCodeRepository
    {
        private readonly ContabContext _context;

        public DiseaseCodeRepository(ContabContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DiseaseCode>> GetDiseaseCodes()
        {
            return await _context.DiseaseCodes.ToListAsync();
        }
        public async Task<DiseaseCode> GetDiseaseCode(int id)
        {
            return await _context.DiseaseCodes.FindAsync(id);
        }

        public async Task<DiseaseCode> AddDiseaseCode(DiseaseCode DiseaseCode)
        {
            _context.DiseaseCodes.Add(DiseaseCode);
            await _context.SaveChangesAsync();
            return DiseaseCode;
        }

        public async Task<DiseaseCode> UpdateDiseaseCode(DiseaseCode DiseaseCode)
        {
            _context.Entry(DiseaseCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return DiseaseCode;
        }

        public async Task<DiseaseCode> DeleteDiseaseCode(int id)
        {
            var DiseaseCode = await _context.DiseaseCodes.FindAsync(id);
            if (DiseaseCode != null)
            {
                _context.DiseaseCodes.Remove(DiseaseCode);
                await _context.SaveChangesAsync();
            }
            return DiseaseCode;
        }
    }
}
