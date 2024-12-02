using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Repository.Impl;

namespace UnitTests
{

    public class BankRepositoryTests : BaseUnitTest
    {
        private readonly Mock<ContabContext> _mockContext;
        private readonly Mock<DbSet<Bank>> _mockDbSet;
        private readonly BankRepository _repository;

        public BankRepositoryTests()
        {
            _mockContext = new Mock<ContabContext>(new DbContextOptions<ContabContext>());
            _mockDbSet = new Mock<DbSet<Bank>>();
            _repository = new BankRepository(_mockContext.Object);

            _mockContext.Setup(m => m.Banks).Returns(_mockDbSet.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllBanks()
        {
            // Arrange
            var banks = new List<Bank>
        {
            new Bank { Id = 1, BankCode = "123", Iban = "IBAN1", Adress = "Address1", Branch = true },
            new Bank { Id = 2, BankCode = "456", Iban = "IBAN2", Adress = "Address2", Branch = false }
        }.AsQueryable();

            _mockDbSet.As<IQueryable<Bank>>().Setup(m => m.Provider).Returns(banks.Provider);
            _mockDbSet.As<IQueryable<Bank>>().Setup(m => m.Expression).Returns(banks.Expression);
            _mockDbSet.As<IQueryable<Bank>>().Setup(m => m.ElementType).Returns(banks.ElementType);
            _mockDbSet.As<IQueryable<Bank>>().Setup(m => m.GetEnumerator()).Returns(banks.GetEnumerator());

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("123", result.First().BankCode);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsBank()
        {
            // Arrange
            var bank = new Bank { Id = 1, BankCode = "123", Iban = "IBAN1", Adress = "Address1", Branch = true };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(bank);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("123", result.BankCode);
        }

        [Fact]
        public async Task AddAsync_AddsBank()
        {
            // Arrange
            var bank = new Bank { Id = 1, BankCode = "123", Iban = "IBAN1", Adress = "Address1", Branch = true };
            _mockDbSet.Setup(m => m.AddAsync(bank, default)).ReturnsAsync((EntityEntry<Bank>)null);

            // Act
            await _repository.AddAsync(bank);

            // Assert
            _mockDbSet.Verify(m => m.AddAsync(bank, default), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_UpdatesBank()
        {
            // Arrange
            var bank = new Bank { Id = 1, BankCode = "123", Iban = "IBAN1", Adress = "Address1", Branch = true };
            _mockDbSet.Setup(m => m.Update(bank)).Returns((EntityEntry<Bank>)null);

            // Act
            await _repository.UpdateAsync(bank);

            // Assert
            _mockDbSet.Verify(m => m.Update(bank), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_DeletesBank()
        {
            // Arrange
            var bank = new Bank { Id = 1, BankCode = "123", Iban = "IBAN1", Adress = "Address1", Branch = true };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(bank);
            _mockDbSet.Setup(m => m.Remove(bank)).Returns((EntityEntry<Bank>)null);

            // Act
            await _repository.DeleteAsync(1);

            // Assert
            _mockDbSet.Verify(m => m.Remove(bank), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
        }
    }

}
