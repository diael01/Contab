using Moq;
using Repository.Interfaces;
using Repository.Models;
using Services;

namespace UnitTests
{

    public class HolidayServiceTests : BaseUnitTest
    {
        private readonly HolidayService _service;
        private readonly Mock<IHolidayRepository> _mockRepository;
        //public HolidayServiceTests()
        //{
        //    _mockRepository = new Mock<IHolidayRepository>();
        //    _service = new HolidayService(_mockRepository.Object);
        //}

        [Fact]
        public async Task GetHolidays_ReturnsHolidays()
        {
            // Arrange
            var holidays = new List<Holiday>
            {
            new Holiday { Id = 1, VacationStartDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow }
            };
            _mockRepository.Setup(repo => repo.GetHolidays()).ReturnsAsync(holidays);
            // Act
            var result = await _service.GetHolidays();
            // Assert
            Assert.Equal(holidays, result);
        }

        [Fact]
        public async Task GetHoliday_ReturnsHoliday()
        {
            // Arrange
            var holiday = new Holiday { Id = 1, VacationStartDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow };
            _mockRepository.Setup(repo => repo.GetHoliday(1)).ReturnsAsync(holiday);
            // Act
            var result = await _service.GetHoliday(1);
            // Assert
            Assert.Equal(holiday, result);
        }
        [Fact]
        public async Task GetHoliday_ReturnsNull_WhenHolidayNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetHoliday(1)).ReturnsAsync((Holiday)null);
            // Act
            var result = await _service.GetHoliday(1);
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task AddHoliday_AddsHoliday()
        {
            // Arrange
            var holiday = new Holiday { Id = 1, VacationStartDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow };
            _mockRepository.Setup(repo => repo.AddHoliday(holiday)).ReturnsAsync(holiday);
            // Act
            var result = await _service.AddHoliday(holiday);
            //11 / 13 / 24, 12:44 PM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/2
            // Assert
            Assert.Equal(holiday, result);
        }
        [Fact]
        public async Task UpdateHoliday_UpdatesHoliday()
        {
            // Arrange
            var holiday = new Holiday { Id = 1, VacationStartDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow };
            _mockRepository.Setup(repo => repo.UpdateHoliday(holiday)).ReturnsAsync(holiday);
            // Act
            var result = await _service.UpdateHoliday(holiday);
            // Assert
            Assert.Equal(holiday, result);
        }
        [Fact]
        public async Task DeleteHoliday_DeletesHoliday()
        {
            // Arrange
            var holiday = new Holiday { Id = 1, VacationStartDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow };
            _mockRepository.Setup(repo => repo.DeleteHoliday(1)).ReturnsAsync(holiday);
            // Act
            var result = await _service.DeleteHoliday(1);
            // Assert
            Assert.Equal(holiday, result);
        }
        [Fact]
        public async Task DeleteHoliday_ReturnsNull_WhenHolidayNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteHoliday(1)).ReturnsAsync((Holiday)null);
            // Act
            var result = await _service.DeleteHoliday(1);
            // Assert
            Assert.Null(result);
        }
    }

}
