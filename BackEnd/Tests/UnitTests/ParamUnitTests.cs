using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Repository.Impl;

namespace UnitTests
{

    public class ParamRepositoryTests
    {
        private readonly Mock<ContabContext> _mockContext;
        private readonly Mock<DbSet<Param>> _mockDbSet;
        private readonly ParamRepository _repository;

        public ParamRepositoryTests()
        {
            _mockContext = new Mock<ContabContext>(new DbContextOptions<ContabContext>());
            _mockDbSet = new Mock<DbSet<Param>>();
            _repository = new ParamRepository(_mockContext.Object);

            _mockContext.Setup(m => m.Params).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllParams()
        {
            // Arrange
            var paramsList = new List<Param>
        {
            new Param { Id = 1, ApplicationVersion = "1.0", CreatedBy = "User1" },
            new Param { Id = 2, ApplicationVersion = "2.0", CreatedBy = "User2" }
        }.AsQueryable();

            _mockDbSet.As<IQueryable<Param>>().Setup(m => m.Provider).Returns(paramsList.Provider);
            _mockDbSet.As<IQueryable<Param>>().Setup(m => m.Expression).Returns(paramsList.Expression);
            _mockDbSet.As<IQueryable<Param>>().Setup(m => m.ElementType).Returns(paramsList.ElementType);
            _mockDbSet.As<IQueryable<Param>>().Setup(m => m.GetEnumerator()).Returns(paramsList.GetEnumerator());

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("1.0", result.First().ApplicationVersion);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsParam()
        {
            // Arrange
            var param = new Param { Id = 1, ApplicationVersion = "1.0", CreatedBy = "User1" };
            _mockDbSet.Setup(m => m.FindAsync((short)1)).ReturnsAsync(param);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("1.0", result.ApplicationVersion);
        }

        [Fact]
        public async Task AddAsync_AddsParam()
        {
            // Arrange
            var param = new Param { Id = 1, ApplicationVersion = "1.0", CreatedBy = "User1" };
            _mockDbSet.Setup(m => m.AddAsync(param, default)).ReturnsAsync((EntityEntry<Param>)null);

            // Act
            await _repository.AddAsync(param);

            // Assert
            _mockDbSet.Verify(m => m.AddAsync(param, default), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_UpdatesParam()
        {
            // Arrange
            var param = new Param { Id = 1, ApplicationVersion = "1.0", CreatedBy = "User1" };
            _mockDbSet.Setup(m => m.Update(param)).Returns((EntityEntry<Param>)null);

            // Act
            await _repository.UpdateAsync(param);

            // Assert
            _mockDbSet.Verify(m => m.Update(param), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_DeletesParam()
        {
            // Arrange
            var param = new Param { Id = 1, ApplicationVersion = "1.0", CreatedBy = "User1" };
            _mockDbSet.Setup(m => m.FindAsync((short)1)).ReturnsAsync(param);
            _mockDbSet.Setup(m => m.Remove(param)).Returns((EntityEntry<Param>)null);

            // Act
            await _repository.DeleteAsync(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(param), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }
    }

}
