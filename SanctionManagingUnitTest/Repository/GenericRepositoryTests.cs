using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SanctionManagingBackend.DAL.Repository;
using SanctionManagingBackend.Data.DBcontext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanctionManagingBackend.Tests.Repository
{
    // Aangepaste DbContext voor tests
    public class TestSanctionContext : SanctionContext
    {
        public TestSanctionContext(DbContextOptions<SanctionContext> options)
            : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestEntity>().HasKey(e => e.Id);
            // Zorg ervoor dat Name verplicht is
            modelBuilder.Entity<TestEntity>().Property(e => e.Name).IsRequired();
        }
    }

    [TestFixture]
    public class GenericRepositoryTests
    {
        private TestSanctionContext _context;
        private GenericRepository<TestEntity> _repository;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<SanctionContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new TestSanctionContext(options);
            _repository = new GenericRepository<TestEntity>(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            // Arrange
            var entities = new List<TestEntity>
            {
                new TestEntity { Name = "Entity1" },
                new TestEntity { Name = "Entity2" }
            };
            await _context.TestEntities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count()); // Gebruik Count() en voeg System.Linq toe
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnEntity_WhenEntityExists()
        {
            // Arrange
            var entity = new TestEntity { Id = 1, Name = "TestName" };
            await _context.TestEntities.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.IsNotNull(result, "Result should not be null");
            Assert.AreEqual(entity.Id, result.Id, "Entity IDs should match");
            Assert.AreEqual(entity.Name, result.Name, "Entity Names should match");
        }

        [Test]
        public async Task AddAsync_ShouldAddEntity()
        {
            // Arrange
            var entity = new TestEntity { Name = "NewEntity" };

            // Act
            await _repository.AddAsync(entity);
            await _repository.SaveAsync(); // Gebruik SaveAsync()

            // Assert
            var addedEntity = await _context.TestEntities.FindAsync(entity.Id);
            Assert.IsNotNull(addedEntity);
            Assert.AreEqual("NewEntity", addedEntity.Name);
        }

        [Test]
        public async Task Update_ShouldUpdateEntity()
        {
            // Arrange
            var entity = new TestEntity { Id = 1, Name = "Original" };
            _context.TestEntities.Add(entity);
            _context.SaveChanges();

            // Act
            entity.Name = "Updated";
            _repository.Update(entity);
            await _repository.SaveAsync(); // Gebruik SaveAsync()

            // Assert
            var updatedEntity = await _context.TestEntities.FindAsync(1);
            Assert.AreEqual("Updated", updatedEntity.Name);
        }

        [Test]
        public async Task Delete_ShouldRemoveEntity_WhenEntityExists()
        {
            // Arrange
            var entity = new TestEntity { Id = 1, Name = "ToBeDeleted" };
            _context.TestEntities.Add(entity);
            _context.SaveChanges();

            // Act
            _repository.Delete(1);
            await _repository.SaveAsync(); // Gebruik SaveAsync()

            // Assert
            var deletedEntity = await _context.TestEntities.FindAsync(1);
            Assert.IsNull(deletedEntity);
        }

        [Test]
        public void Delete_ShouldThrowArgumentException_WhenEntityDoesNotExist()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _repository.Delete(1));
        }

        [Test]
        public async Task SaveAsync_ShouldSaveChanges()
        {
            // Arrange
            var entity = new TestEntity { Id = 1, Name = "SavedEntity" };
            await _repository.AddAsync(entity);

            // Act
            await _repository.SaveAsync();

            // Assert
            var savedEntity = await _context.TestEntities.FindAsync(1);
            Assert.IsNotNull(savedEntity);
            Assert.AreEqual("SavedEntity", savedEntity.Name);
        }
    }

    // Dummy class voor testing
    public class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
