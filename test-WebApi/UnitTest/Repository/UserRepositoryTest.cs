
using System;
using Moq;
using Xunit;
using WebApi.src.Infra;
using WebApi.src.Entities;
using WebApi.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebApi.UnitTest.Repository;

    public class UserRepositoryTest : IDisposable
    {
        private readonly DataContext _context;
        private readonly UserRepository _userRepository;

        public UserRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=MIRACLE\\SQLEXPRESS;Database=TestTest;Integrated Security=True;TrustServerCertificate=True").Options;
            _context = new DataContext(options);
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
            _userRepository = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }


        [Theory(DisplayName = "Test GetUserById")]
        [InlineData(1)]
        [InlineData(2)]
        public async Task TestGetUserById(decimal id)
        {
            // Arrange
            _context.User.Add(new User { Username = "User 1" });
            _context.User.Add(new User { Username = "User 2" });
            await _context.SaveChangesAsync();

            // Act
            var result = await _userRepository.GetUserById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            Assert.Equal($"User {id}", result.Username);
        }

        [Fact(DisplayName = "Test GetUserById with null id")]
        public async Task TestGetUserByIdWithNullId()
        {
            // Arrange
            _context.User.Add(new User { Username = "User 1" });
            _context.User.Add(new User { Username = "User 2" });
            await _context.SaveChangesAsync();

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _userRepository.GetUserById(0));

            // Assert
            Assert.Equal("Id is null", exception.Message);
        }

        [Fact(DisplayName = "Test GetUserById with not found user")]
        public async Task TestGetUserByIdWithNotFoundUser()
        {
            // Arrange
            _context.User.Add(new User { Username = "User 1" });
            _context.User.Add(new User { Username = "User 2" });
            await _context.SaveChangesAsync();

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _userRepository.GetUserById(3));

            // Assert
            Assert.Equal("User not found", exception.Message);
        }

        [Fact(DisplayName = "Test AddUser")]
        public async Task TestAddUser()
        {
            // Arrange
            var user = new User { Username = "User 1" };

            // Act
            await _userRepository.AddUser(user);

            // Assert
            var result = await _context.User.FirstOrDefaultAsync(x => x.Username == "User 1");
            Assert.NotNull(result);
            Assert.Equal("User 1", result.Username);
        }

        [Fact(DisplayName = "Test AddUser with null user")]
        public async Task TestAddUserWithNullUser()
        {
            // Arrange
            User user = null;

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _userRepository.AddUser(user));

            // Assert
            Assert.Equal("Value cannot be null. (Parameter 'entity')", exception.Message);
        }


    }
