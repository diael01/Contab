using Contracts.Interfaces.Services;
using Repository.Interfaces;
using Repository.Models;
public class BankService : IBankService
{
    private readonly IBankRepository _repository;
    public BankService(IBankRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Bank>> GetBanks()
    {
        return await _repository.GetBanks();
    }
    public async Task<Bank> GetBank(int id)
    {
        return await _repository.GetBank(id);
    }
    public async Task<Bank> AddBank(Bank bank)
    {
        return await _repository.AddBank(bank);
    }
    public async Task<Bank> UpdateBank(Bank bank)
    {
        return await _repository.UpdateBank(bank);
    }
    public async Task<Bank> DeleteBank(int id)
    {
        return await _repository.DeleteBank(id);
    }
}