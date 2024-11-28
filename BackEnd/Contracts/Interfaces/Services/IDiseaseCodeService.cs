using Repository.Models;

namespace Contracts.Interfaces.Services
{
    public interface IDiseaseCodeService
    {
        Task<IEnumerable<DiseaseCode>> GetDiseaseCodes();
        Task<DiseaseCode> GetDiseaseCode(int id);
        Task<DiseaseCode> AddDiseaseCode(DiseaseCode disease);
        Task<DiseaseCode> UpdateDiseaseCode(DiseaseCode disease);
        Task<DiseaseCode> DeleteDiseaseCode(int id);
    }
}