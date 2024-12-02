using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Repository.Impl;

namespace UnitTests
{
    public class DiseaseCodeRepositoryTests
    {
        private readonly Mock<ContabContext> _mockContext;
        private readonly Mock<DbSet<DiseaseCode>> _mockDbSet;
        private readonly DiseaseCodeRepository _repository;

        public DiseaseCodeRepositoryTests()
        {
            _mockContext = new Mock<ContabContext>(new DbContextOptions<ContabContext>());
            _mockDbSet = new Mock<DbSet<DiseaseCode>>();
            _repository = new DiseaseCodeRepository(_mockContext.Object);

            _mockContext.Setup(m => m.DiseaseCodes).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllDiseaseCodes()
        {
            // Arrange
            var diseaseCodes = new List<DiseaseCode>
        {
            new DiseaseCode { Id = 1, DiseaseCode1 = "C1", DiseaseDescription = "Description1" },
            new DiseaseCode { Id = 2, DiseaseCode1 = "C2", DiseaseDescription = "Description2" }
        }.AsQueryable();

            _mockDbSet.As<IQueryable<DiseaseCode>>().Setup(m => m.Provider).Returns(diseaseCodes.Provider);
            _mockDbSet.As<IQueryable<DiseaseCode>>().Setup(m => m.Expression).Returns(diseaseCodes.Expression);
            _mockDbSet.As<IQueryable<DiseaseCode>>().Setup(m => m.ElementType).Returns(diseaseCodes.ElementType);
            _mockDbSet.As<IQueryable<DiseaseCode>>().Setup(m => m.GetEnumerator()).Returns(diseaseCodes.GetEnumerator());

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("C1", result.First().DiseaseCode1);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsDiseaseCode()
        {
            // Arrange
            var diseaseCode = new DiseaseCode { Id = 1, DiseaseCode1 = "C1", DiseaseDescription = "Description1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(diseaseCode);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("C1", result.DiseaseCode1);
        }

        [Fact]
        public async Task AddAsync_AddsDiseaseCode()
        {
            // Arrange
            var diseaseCode = new DiseaseCode { Id = 1, DiseaseCode1 = "C1", DiseaseDescription = "Description1" };
            _mockDbSet.Setup(m => m.AddAsync(diseaseCode, default)).ReturnsAsync((EntityEntry<DiseaseCode>)null);

            // Act
            await _repository.AddAsync(diseaseCode);

            // Assert
            _mockDbSet.Verify(m => m.AddAsync(diseaseCode, default), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_UpdatesDiseaseCode()
        {
            // Arrange
            var diseaseCode = new DiseaseCode { Id = 1, DiseaseCode1 = "C1", DiseaseDescription = "Description1" };
            _mockDbSet.Setup(m => m.Update(diseaseCode)).Returns((EntityEntry<DiseaseCode>)null);

            // Act
            await _repository.UpdateAsync(diseaseCode);

            // Assert
            _mockDbSet.Verify(m => m.Update(diseaseCode), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_DeletesDiseaseCode()
        {
            // Arrange
            var diseaseCode = new DiseaseCode { Id = 1, DiseaseCode1 = "C1", DiseaseDescription = "Description1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(diseaseCode);
            _mockDbSet.Setup(m => m.Remove(diseaseCode)).Returns((EntityEntry<DiseaseCode>)null);

            // Act
            await _repository.DeleteAsync(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(diseaseCode), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }
    }

}
