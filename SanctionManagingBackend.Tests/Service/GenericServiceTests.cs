
using AutoMapper;
using Moq;
using SanctionManagingBackend.ApplicationLayer.Service;
using SanctionManagingBackend.DAL.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanctionManagingBackend.Tests
{
    [TestFixture]
    public class GenericServiceTests
    {
        private Mock<IGenericRepository<TestEntity>> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private GenericService<TestEntity, TestDto> _service;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IGenericRepository<TestEntity>>();
            _mapperMock = new Mock<IMapper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _service = new GenericService<TestEntity, TestDto>(_repositoryMock.Object, _mapperMock.Object, _unitOfWorkMock.Object);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnMappedDtos()
        {
            // Arrange
            var entities = new List<TestEntity> { new TestEntity() };
            var dtos = new List<TestDto> { new TestDto() };
            _repositoryMock.Setup(r => r.GetAllAsync(null, null, "")).ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<IEnumerable<TestDto>>(entities)).Returns(dtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.AreEqual(dtos, result);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnMappedDto()
        {
            // Arrange
            var entity = new TestEntity();
            var dto = new TestDto();
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>(), "")).ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map<TestDto>(entity)).Returns(dto);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.AreEqual(dto, result);
        }

        [Test]
        public async Task AddAsync_ShouldAddEntityAndSave()
        {
            // Arrange
            var dto = new TestDto();
            var entity = new TestEntity();
            _mapperMock.Setup(m => m.Map<TestEntity>(dto)).Returns(entity);

            // Act
            await _service.AddAsync(dto);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(entity), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_ShouldUpdateEntityAndSave()
        {
            // Arrange
            var dto = new TestDto();
            var entity = new TestEntity();
            _mapperMock.Setup(m => m.Map<TestEntity>(dto)).Returns(entity);

            // Act
            await _service.UpdateAsync(dto);

            // Assert
            _repositoryMock.Verify(r => r.Update(entity), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteEntityAndSave()
        {
            // Act
            await _service.DeleteAsync(1);

            // Assert
            _repositoryMock.Verify(r => r.Delete(1), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveAsync(), Times.Once);
        }
    }

    public class TestEntity { }
    public class TestDto { }
}
