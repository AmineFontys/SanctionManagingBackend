using AutoMapper;
using Moq;
using NUnit.Framework;
using SanctionManagingBackend.ApplicationLayer.Service;
using SanctionManagingBackend.DAL.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanctionManagingBackend.Tests.Service
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
        public async Task GetAllAsync_ShouldReturnAllDtos()
        {
            // Arrange
            var entities = new List<TestEntity> { new TestEntity(), new TestEntity() };
            var dtos = new List<TestDto> { new TestDto(), new TestDto() };

            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(entities);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<TestDto>>(entities)).Returns(dtos);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.AreEqual(dtos, result);
            _repositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<IEnumerable<TestDto>>(entities), Times.Once);
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnDto_WhenEntityExists()
        {
            // Arrange
            var entity = new TestEntity();
            var dto = new TestDto();

            _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(entity);
            _mapperMock.Setup(mapper => mapper.Map<TestDto>(entity)).Returns(dto);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.AreEqual(dto, result);
            _repositoryMock.Verify(repo => repo.GetByIdAsync(1), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<TestDto>(entity), Times.Once);
        }

        [Test]
        public async Task AddAsync_ShouldAddEntity()
        {
            // Arrange
            var dto = new TestDto();
            var entity = new TestEntity();

            _mapperMock.Setup(mapper => mapper.Map<TestEntity>(dto)).Returns(entity);

            // Act
            await _service.AddAsync(dto);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(entity), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_ShouldUpdateEntity()
        {
            // Arrange
            var dto = new TestDto();
            var entity = new TestEntity();

            _mapperMock.Setup(mapper => mapper.Map<TestEntity>(dto)).Returns(entity);

            // Act
            await _service.UpdateAsync(dto);

            // Assert
            _repositoryMock.Verify(repo => repo.Update(entity), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteEntity()
        {
            // Act
            await _service.DeleteAsync(1);

            // Assert
            _repositoryMock.Verify(repo => repo.Delete(1), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(), Times.Once);
        }
    }

    // Dummy classes for testing
    public class TestEntity { }
    public class TestDto { }
}
