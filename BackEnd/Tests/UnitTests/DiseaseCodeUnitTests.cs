using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Repository.Impl;
using Repository.Models;

namespace UnitTests
{
    public class DiseaseCodeRepositoryTests : BaseUnitTest
    {
        //private readonly DiseaseCodeService _service;
        //private readonly Mock<IDiseaseCodeRepository> _mockRepository;
        private readonly Mock<ContabContext> _mockContext;
        private readonly DiseaseCodeRepository _repository;
        private readonly Mock<DbSet<DiseaseCode>> _mockSet;

        //public DiseaseCodeRepositoryTests()
        //{
        //    _mockContext = new Mock<ContabContext>();
        //    _mockSet = new Mock<DbSet<DiseaseCode>>();
        //    _repository = new DiseaseCodeRepository(_mockContext.Object);
        //}

        [Fact]
        public async Task Create_ShouldAddDiseaseCode()
        {
            var diseaseCode = new DiseaseCode { DiseaseCode1 = "A01", DiseaseDescription = "Typhoid", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, CreatedBy = "Admin", UpdatedBy = "Admin" };

            _mockSet.Setup(m => m.Add(It.IsAny<DiseaseCode>())).Callback<DiseaseCode>(dc => dc.Id = 1);
            _mockContext.Setup(m => m.DiseaseCodes).Returns(_mockSet.Object);

            var result = await _repository.AddDiseaseCode(diseaseCode);

            Assert.NotNull(result);
            Assert.Equal("A01", result.DiseaseCode1);
            _mockSet.Verify(m => m.Add(It.IsAny<DiseaseCode>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Read_ShouldReturnDiseaseCode()
        {
            var diseaseCode = new DiseaseCode { Id = 1, DiseaseCode1 = "A00", DiseaseDescription = "Cholera", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, CreatedBy = "Admin", UpdatedBy = "Admin" };
            _mockSet.Setup(m => m.FindAsync(It.IsAny<int>())).ReturnsAsync(diseaseCode);
            _mockContext.Setup(m => m.DiseaseCodes).Returns(_mockSet.Object);

            var result = await _repository.GetDiseaseCode(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("A00", result.DiseaseCode1);
        }

        [Fact]
        public async Task Update_ShouldModifyDiseaseCode()
        {
            var diseaseCode = new DiseaseCode { Id = 1, DiseaseCode1 = "A00", DiseaseDescription = "Cholera", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, CreatedBy = "Admin", UpdatedBy = "Admin" };
            _mockSet.Setup(m => m.Update(It.IsAny<DiseaseCode>())).Returns((EntityEntry<DiseaseCode>)null);
            _mockContext.Setup(m => m.DiseaseCodes).Returns(_mockSet.Object);

            diseaseCode.DiseaseCode1 = "A99";
            diseaseCode.DiseaseDescription = "Updated Disease";

            var result = await _repository.UpdateDiseaseCode(diseaseCode);

            Assert.NotNull(result);
            Assert.Equal("A99", result.DiseaseCode1);
            Assert.Equal("Updated Disease", result.DiseaseDescription);
            _mockSet.Verify(m => m.Update(It.IsAny<DiseaseCode>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Delete_ShouldRemoveDiseaseCode()
        {
            var diseaseCode = new DiseaseCode { Id = 1, DiseaseCode1 = "A00", DiseaseDescription = "Cholera", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, CreatedBy = "Admin", UpdatedBy = "Admin" };
            _mockSet.Setup(m => m.FindAsync(It.IsAny<int>())).ReturnsAsync(diseaseCode);
            _mockContext.Setup(m => m.DiseaseCodes).Returns(_mockSet.Object);

            var result = await _repository.DeleteDiseaseCode(1);

            Assert.NotNull(result);
            _mockSet.Verify(m => m.Remove(It.IsAny<DiseaseCode>()), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
