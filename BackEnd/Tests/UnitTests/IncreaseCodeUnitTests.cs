using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Repository.Impl;

namespace UnitTests
{

    public class IncreaseCodeRepositoryTests
    {
        private readonly Mock<ContabContext> _mockContext;
        private readonly Mock<DbSet<IncreaseCode>> _mockDbSet;
        private readonly IncreaseCodeRepository _repository;

        public IncreaseCodeRepositoryTests()
        {
            _mockContext = new Mock<ContabContext>(new DbContextOptions<ContabContext>());
            _mockDbSet = new Mock<DbSet<IncreaseCode>>();
            _repository = new IncreaseCodeRepository(_mockContext.Object);

            _mockContext.Setup(m => m.IncreaseCodes).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllIncreaseCodes()
        {
            // Arrange
            var increaseCodes = new List<IncreaseCode>
        {
            new IncreaseCode { Id = 1, IncreaseCode1 = "IC1", IncreaseDescription = "Increase Desc 1" },
            new IncreaseCode { Id = 2, IncreaseCode1 = "IC2", IncreaseDescription = "Increase Desc 2" }
        }.AsQueryable();

            _mockDbSet.As<IQueryable<IncreaseCode>>().Setup(m => m.Provider).Returns(increaseCodes.Provider);
            _mockDbSet.As<IQueryable<IncreaseCode>>().Setup(m => m.Expression).Returns(increaseCodes.Expression);
            _mockDbSet.As<IQueryable<IncreaseCode>>().Setup(m => m.ElementType).Returns(increaseCodes.ElementType);
            _mockDbSet.As<IQueryable<IncreaseCode>>().Setup(m => m.GetEnumerator()).Returns(increaseCodes.GetEnumerator());

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("IC1", result.First().IncreaseCode1);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsIncreaseCode()
        {
            // Arrange
            var increaseCode = new IncreaseCode { Id = 1, IncreaseCode1 = "IC1", IncreaseDescription = "Increase Desc 1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(increaseCode);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("IC1", result.IncreaseCode1);
        }

        [Fact]
        public async Task AddAsync_AddsIncreaseCode()
        {
            // Arrange
            var increaseCode = new IncreaseCode { Id = 1, IncreaseCode1 = "IC1", IncreaseDescription = "Increase Desc 1" };
            _mockDbSet.Setup(m => m.AddAsync(increaseCode, default)).ReturnsAsync((EntityEntry<IncreaseCode>)null);

            // Act
            await _repository.AddAsync(increaseCode);

            // Assert
            _mockDbSet.Verify(m => m.AddAsync(increaseCode, default), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_UpdatesIncreaseCode()
        {
            // Arrange
            var increaseCode = new IncreaseCode { Id = 1, IncreaseCode1 = "IC1", IncreaseDescription = "Increase Desc 1" };
            _mockDbSet.Setup(m => m.Update(increaseCode)).Returns((EntityEntry<IncreaseCode>)null);

            // Act
            await _repository.UpdateAsync(increaseCode);

            // Assert
            _mockDbSet.Verify(m => m.Update(increaseCode), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_DeletesIncreaseCode()
        {
            // Arrange
            var increaseCode = new IncreaseCode { Id = 1, IncreaseCode1 = "IC1", IncreaseDescription = "Increase Desc 1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(increaseCode);
            _mockDbSet.Setup(m => m.Remove(increaseCode)).Returns((EntityEntry<IncreaseCode>)null);

            // Act
            await _repository.DeleteAsync(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(increaseCode), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }
    }
}

