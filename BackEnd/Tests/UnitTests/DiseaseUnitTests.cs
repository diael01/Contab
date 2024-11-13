using Moq;
using Repository.Interfaces;
using Repository.Models;
using Services;

namespace UnitTests
{

    public class DiseaseServiceTests : BaseUnitTest
    {
        private readonly DiseaseService _service;
        private readonly Mock<IDiseaseRepository> _mockRepository;
        //public DiseaseServiceTests()
        //{
        //    _mockRepository = new Mock<IDiseaseRepository>();
        //    _service = new DiseaseService(_mockRepository.Object);
        //}
        [Fact]
        public async Task GetDiseases_ReturnsDiseases()
        {
            // Arrange
            var diseases = new List<Disease> { new Disease { Id = 1, CodeDisease = 1001 } };
            _mockRepository.Setup(repo => repo.GetDiseases()).ReturnsAsync(diseases);
            // Act
            var result = await _service.GetDiseases();
            // Assert
            Assert.Equal(diseases, result);
        }
        [Fact]
        public async Task GetDisease_ReturnsDisease()
        {
            // Arrange
            var disease = new Disease { Id = 1, CodeDisease = 1001 };
            _mockRepository.Setup(repo => repo.GetDisease(1)).ReturnsAsync(disease);
            // Act
            var result = await _service.GetDisease(1);
            // Assert
            Assert.Equal(disease, result);
        }
        [Fact]
        public async Task GetDisease_ReturnsNull_WhenDiseaseNotFound()
        {
            // Arrange
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/3
            _mockRepository.Setup(repo => repo.GetDisease(1)).ReturnsAsync((Disease)null);
            // Act
            var result = await _service.GetDisease(1);
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task AddDisease_AddsDisease()
        {
            // Arrange
            var disease = new Disease { Id = 1, CodeDisease = 1001 };
            _mockRepository.Setup(repo => repo.AddDisease(disease)).ReturnsAsync(disease);
            // Act
            var result = await _service.AddDisease(disease);
            // Assert
            Assert.Equal(disease, result);
        }
        [Fact]
        public async Task UpdateDisease_UpdatesDisease()
        {
            // Arrange
            var disease = new Disease { Id = 1, CodeDisease = 1001 };
            _mockRepository.Setup(repo => repo.UpdateDisease(disease)).ReturnsAsync(disease);
            // Act
            var result = await _service.UpdateDisease(disease);
            // Assert
            Assert.Equal(disease, result);
        }
        [Fact]
        public async Task DeleteDisease_DeletesDisease()
        {
            // Arrange
            var disease = new Disease { Id = 1, CodeDisease = 1001 };
            _mockRepository.Setup(repo => repo.DeleteDisease(1)).ReturnsAsync(disease);
            // Act
            var result = await _service.DeleteDisease(1);
            // Assert
            Assert.Equal(disease, result);

            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 2/3
        }
        [Fact]
        public async Task DeleteDisease_ReturnsNull_WhenDiseaseNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteDisease(1)).ReturnsAsync((Disease)null);
            // Act
            var result = await _service.DeleteDisease(1);
            // Assert
            Assert.Null(result);
        }
    }

}
