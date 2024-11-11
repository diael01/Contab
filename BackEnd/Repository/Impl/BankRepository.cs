using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Impl
{
    public class BankRepository : IBankRepository
    {
        private readonly ContabContext _context;
        public BankRepository(ContabContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await _context.Banks.ToListAsync();
        }
        public async Task<Bank> GetBank(int id)
        {
            return await _context.Banks.FindAsync(id);
        }
        public async Task<Bank> AddBank(Bank bank)
        {
            _context.Banks.Add(bank);
            await _context.SaveChangesAsync();
            return bank;
        }
        public async Task<Bank> UpdateBank(Bank bank)
        {
            _context.Entry(bank).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return bank;
        }
        public async Task<Bank> DeleteBank(int id)
        {
            var bank = await _context.Banks.FindAsync(id);
            if (bank != null)
            {
                _context.Banks.Remove(bank);
                await _context.SaveChangesAsync();
            }
            return bank;
        }
    }
}