using Moq;
using Repository.Interfaces;
using Repository.Models;

namespace UnitTests
{
    public class BankUnitTests : BaseUnitTest
    {
        private readonly BankService _service;
        private readonly Mock<IBankRepository> _mockRepository;
        public BankUnitTests()
        {
            _mockRepository = new Mock<IBankRepository>();
            _service = new BankService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetBanks_ReturnsBanks()
        {
            // Arrange
            var banks = new List<Bank> { new Bank { Id = 1, BankCode = "001", Iban = "IBAN001" }
            };
            _mockRepository.Setup(repo => repo.GetBanks()).ReturnsAsync(banks);

            // Act
            var result = await _service.GetBanks();
            // Assert
            Assert.Equal(banks, result);
        }
    }
}
