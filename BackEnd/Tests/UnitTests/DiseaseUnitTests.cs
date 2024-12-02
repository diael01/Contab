using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Repository.Impl;

namespace UnitTests
{
    public class DiseaseRepositoryTests
    {
        private readonly Mock<ContabContext> _mockContext;
        private readonly Mock<DbSet<Disease>> _mockDbSet;
        private readonly DiseaseRepository _repository;

        public DiseaseRepositoryTests()
        {
            _mockContext = new Mock<ContabContext>(new DbContextOptions<ContabContext>());
            _mockDbSet = new Mock<DbSet<Disease>>();
            _repository = new DiseaseRepository(_mockContext.Object);

            _mockContext.Setup(m => m.Diseases).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllDiseases()
        {
            // Arrange
            var diseases = new List<Disease>
        {
            new Disease { Id = 1, CodeDisease = 101, MedCertificateCode = "A1", MedCertificateSerie = "S1" },
            new Disease { Id = 2, CodeDisease = 102, MedCertificateCode = "A2", MedCertificateSerie = "S2" }
        }.AsQueryable();

            _mockDbSet.As<IQueryable<Disease>>().Setup(m => m.Provider).Returns(diseases.Provider);
            _mockDbSet.As<IQueryable<Disease>>().Setup(m => m.Expression).Returns(diseases.Expression);
            _mockDbSet.As<IQueryable<Disease>>().Setup(m => m.ElementType).Returns(diseases.ElementType);
            _mockDbSet.As<IQueryable<Disease>>().Setup(m => m.GetEnumerator()).Returns(diseases.GetEnumerator());

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(101, result.First().CodeDisease);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsDisease()
        {
            // Arrange
            var disease = new Disease { Id = 1, CodeDisease = 101, MedCertificateCode = "A1", MedCertificateSerie = "S1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(disease);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(101, result.CodeDisease);
        }

        [Fact]
        public async Task AddAsync_AddsDisease()
        {
            // Arrange
            var disease = new Disease { Id = 1, CodeDisease = 101, MedCertificateCode = "A1", MedCertificateSerie = "S1" };
            _mockDbSet.Setup(m => m.AddAsync(disease, default)).ReturnsAsync((EntityEntry<Disease>)null);

            // Act
            await _repository.AddAsync(disease);

            // Assert
            _mockDbSet.Verify(m => m.AddAsync(disease, default), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_UpdatesDisease()
        {
            // Arrange
            var disease = new Disease { Id = 1, CodeDisease = 101, MedCertificateCode = "A1", MedCertificateSerie = "S1" };
            _mockDbSet.Setup(m => m.Update(disease)).Returns((EntityEntry<Disease>)null);

            // Act
            await _repository.UpdateAsync(disease);

            // Assert
            _mockDbSet.Verify(m => m.Update(disease), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_DeletesDisease()
        {
            // Arrange
            var disease = new Disease { Id = 1, CodeDisease = 101, MedCertificateCode = "A1", MedCertificateSerie = "S1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(disease);
            _mockDbSet.Setup(m => m.Remove(disease)).Returns((EntityEntry<Disease>)null);

            // Act
            await _repository.DeleteAsync(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(disease), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }
    }


}
