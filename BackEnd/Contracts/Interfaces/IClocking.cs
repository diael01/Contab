namespace Contracts.Interfaces
{

    public interface IClockingService
    {
        Task<decimal?> UpdateClocking1Async(string empId); //advance

        Task<decimal?> UpdateClocking2Async(string empId); //liquidation

    }

}
