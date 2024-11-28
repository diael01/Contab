using Repository.Models;

namespace Repository.Interfaces
{
    public interface IDiseaseCodeRepository
    {
        Task<IEnumerable<DiseaseCode>> GetDiseaseCodes();
        Task<DiseaseCode> GetDiseaseCode(int id);
        Task<DiseaseCode> AddDiseaseCode(DiseaseCode disease);
        Task<DiseaseCode> UpdateDiseaseCode(DiseaseCode disease);
        Task<DiseaseCode> DeleteDiseaseCode(int id);
    }
}
