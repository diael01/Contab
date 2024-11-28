using Contracts.Interfaces.Services;
using Repository.Interfaces;
using Repository.Models;

namespace Services
{

    public class DiseaseCodeService : IDiseaseCodeService
    {
        private readonly IDiseaseCodeRepository _repository;

        Task<DiseaseCode> IDiseaseCodeService.AddDiseaseCode(DiseaseCode disease)
        {
            throw new NotImplementedException();
        }

        Task<DiseaseCode> IDiseaseCodeService.DeleteDiseaseCode(int id)
        {
            throw new NotImplementedException();
        }

        Task<DiseaseCode> IDiseaseCodeService.GetDiseaseCode(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<DiseaseCode>> IDiseaseCodeService.GetDiseaseCodes()
        {
            throw new NotImplementedException();
        }

        Task<DiseaseCode> IDiseaseCodeService.UpdateDiseaseCode(DiseaseCode disease)
        {
            throw new NotImplementedException();
        }
    }
}
