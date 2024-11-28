using Moq;
using Repository.Interfaces;
using Repository.Models;
using Services;

namespace UnitTests
{

    public class ParamServiceTests : BaseUnitTest
    {
        private readonly ParamService _service;
        private readonly Mock<IParamRepository> _mockRepository;
        //public ParamServiceTests()
        //{
        //    _mockRepository = new Mock<IParamRepository>();
        //    _service = new ParamService(_mockRepository.Object);
        //}
        [Fact]
        public async Task GetParams_ReturnsParams()
        {
            // Arrange
            var paramsList = new List<Param>
{
new Param { Id = 1, ProcessingDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow }
};
            _mockRepository.Setup(repo => repo.GetParams()).ReturnsAsync(paramsList);
            // Act
            var result = await _service.GetParams();
            // Assert
            Assert.Equal(paramsList, result);
        }
        [Fact]
        public async Task GetParam_ReturnsParam()
        {
            // Arrange
            var param = new Param { Id = 1, ProcessingDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow };
            _mockRepository.Setup(repo => repo.GetParam(1)).ReturnsAsync(param);
            // Act
            var result = await _service.GetParam(1);
            // Assert
            Assert.Equal(param, result);
        }
        [Fact]
        public async Task GetParam_ReturnsNull_WhenParamNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetParam(1)).ReturnsAsync((Param)null);
            // Act
            var result = await _service.GetParam(1);
            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task AddParam_AddsParam()
        {
            // Arrange
            var param = new Param { Id = 1, ProcessingDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow };
            _mockRepository.Setup(repo => repo.AddParam(param)).ReturnsAsync(param);
            //11 / 14 / 24, 6:33 PM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/2
            // Act
            var result = await _service.AddParam(param);
            // Assert
            Assert.Equal(param, result);
        }
        [Fact]
        public async Task UpdateParam_UpdatesParam()
        {
            // Arrange
            var param = new Param { Id = 1, ProcessingDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow };
            _mockRepository.Setup(repo => repo.UpdateParam(param)).ReturnsAsync(param);
            // Act
            var result = await _service.UpdateParam(param);
            // Assert
            Assert.Equal(param, result);
        }
        [Fact]
        public async Task DeleteParam_DeletesParam()
        {
            // Arrange
            var param = new Param { Id = 1, ProcessingDate = DateTime.UtcNow, UpdatedBy = "TestUser", UpdatedAt = DateTime.UtcNow };
            _mockRepository.Setup(repo => repo.DeleteParam(1)).ReturnsAsync(param);
            // Act
            var result = await _service.DeleteParam(1);
            // Assert
            Assert.Equal(param, result);
        }
        [Fact]
        public async Task DeleteParam_ReturnsNull_WhenParamNotFound()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteParam(1)).ReturnsAsync((Param)null);
            // Act
            var result = await _service.DeleteParam(1);
            // Assert
            Assert.Null(result);
        }
    }
}
