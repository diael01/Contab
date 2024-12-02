using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Repository.Impl;

namespace UnitTests
{
    public class HolidayRepositoryTests
    {
        private readonly Mock<ContabContext> _mockContext;
        private readonly Mock<DbSet<Holiday>> _mockDbSet;
        private readonly HolidayRepository _repository;

        public HolidayRepositoryTests()
        {
            _mockContext = new Mock<ContabContext>(new DbContextOptions<ContabContext>());
            _mockDbSet = new Mock<DbSet<Holiday>>();
            _repository = new HolidayRepository(_mockContext.Object);

            _mockContext.Setup(m => m.Holidays).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllHolidays()
        {
            // Arrange
            var holidays = new List<Holiday>
        {
            new Holiday { Id = 1, EmpNode = new HierarchyId(), CalculationBase = 1000, IncreaseCode = "A1" },
            new Holiday { Id = 2, EmpNode = new HierarchyId(), CalculationBase = 2000, IncreaseCode = "A2" }
        }.AsQueryable();

            _mockDbSet.As<IQueryable<Holiday>>().Setup(m => m.Provider).Returns(holidays.Provider);
            _mockDbSet.As<IQueryable<Holiday>>().Setup(m => m.Expression).Returns(holidays.Expression);
            _mockDbSet.As<IQueryable<Holiday>>().Setup(m => m.ElementType).Returns(holidays.ElementType);
            _mockDbSet.As<IQueryable<Holiday>>().Setup(m => m.GetEnumerator()).Returns(holidays.GetEnumerator());

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(1000, result.First().CalculationBase);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsHoliday()
        {
            // Arrange
            var holiday = new Holiday { Id = 1, EmpNode = new HierarchyId(), CalculationBase = 1000, IncreaseCode = "A1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(holiday);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1000, result.CalculationBase);
        }

        [Fact]
        public async Task AddAsync_AddsHoliday()
        {
            // Arrange
            var holiday = new Holiday { Id = 1, EmpNode = new HierarchyId(), CalculationBase = 1000, IncreaseCode = "A1" };
            _mockDbSet.Setup(m => m.AddAsync(holiday, default)).ReturnsAsync((EntityEntry<Holiday>)null);

            // Act
            await _repository.AddAsync(holiday);

            // Assert
            _mockDbSet.Verify(m => m.AddAsync(holiday, default), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_UpdatesHoliday()
        {
            // Arrange
            var holiday = new Holiday { Id = 1, EmpNode = new HierarchyId(), CalculationBase = 1000, IncreaseCode = "A1" };
            _mockDbSet.Setup(m => m.Update(holiday)).Returns((EntityEntry<Holiday>)null);

            // Act
            await _repository.UpdateAsync(holiday);

            // Assert
            _mockDbSet.Verify(m => m.Update(holiday), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_DeletesHoliday()
        {
            // Arrange
            var holiday = new Holiday { Id = 1, EmpNode = new HierarchyId(), CalculationBase = 1000, IncreaseCode = "A1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(holiday);
            _mockDbSet.Setup(m => m.Remove(holiday)).Returns((EntityEntry<Holiday>)null);

            // Act
            await _repository.DeleteAsync(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(holiday), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }
    }


}
