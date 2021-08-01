using AutoMapper;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Mapper;
using GenericApi.Bl.Validations;
using GenericApi.Core.Settings;
using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Test
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly User _emmanuel = new User
        {
            Name = "Emmanuel",
            MiddleName = "Enrique",
            LastName = "Jimenez",
            SecondLastName = "Pimentel",
            Dob = new System.DateTime(1996, 06, 16),
            DocumentType = Core.Enums.DocumentType.ID,
            DocumentTypeValue = "22500851658",
            Gender = Core.Enums.Gender.MALE,
            UserName = "emmanuel",
            Password = BCrypt.Net.BCrypt.HashPassword("Hola1234,")
        };

        private readonly User _Pedro = new User
        {
            Name = "Pedro",
            MiddleName = "Josue",
            LastName = "Rodriguez",
            SecondLastName = "Alvarez",
            Dob = new System.DateTime(2001, 12, 26),
            DocumentType = Core.Enums.DocumentType.ID,
            DocumentTypeValue = "40232338166",
            Gender = Core.Enums.Gender.MALE,
            UserName = "pedrord",
            Password = BCrypt.Net.BCrypt.HashPassword("Hola1234")
        };

        public UserServiceTests()
        {
            #region Autommaper

            var mapper = new MapperConfiguration(x => x.AddProfile<MainProfile>())
               .CreateMapper();

            #endregion

            #region Repository

            var optionsBuilder = new DbContextOptionsBuilder<WorkShopContext>();
            optionsBuilder.UseInMemoryDatabase("WorkShop2");
            var context = new WorkShopContext(optionsBuilder.Options);
            context.AddRange(_emmanuel, _Pedro);
            context.SaveChanges();

            IUserRepository respository = new UserRepository(context);

            #endregion

            #region Validator

            var validator = new UserValidator();

            #endregion

            #region Option Settings

            var settings = Options.Create(new JwtSettings
            {
                ExpiresInMinutes = 10,
                Secret = "0263875b-b775-4426-938c-ab7c04c74b22"
            });

            #endregion

            _userService = new UserService(respository, mapper, validator, settings);
        }

        [Fact]
        public async Task ShouldSaveUserAsync()
        {
            //Arrange
            var requestDto = new UserDto
            {
                Name = "Emmanuel",
                MiddleName = "Enrique",
                LastName = "Jimenez",
                SecondLastName = "Pimentel",
                Dob = new System.DateTime(1996, 06, 16),
                DocumentType = Core.Enums.DocumentType.ID,
                DocumentTypeValue = "22500851658",
                Gender = Core.Enums.Gender.MALE,
                UserName = "enrique",
                Password = "Hola1234,"
            };

            //Act
            var result = await _userService.AddAsync(requestDto);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetUserGeAllAsync()
        {
            //Act
            var result = await _userService.GetAllAsync();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldDeleteUserAsync()
        {
            //Arrange
            var id = 1;

            //Act
            var result = await _userService.DeleteByIdAsync(id);

            //Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }

        [Fact]
        public async Task ShouldUpdateUserAsync()
        {
            //Arrange
            var id = 2;

            var requestDto = new UserDto
            {
                Id = 2,
                Name = "Enmanuel",
                MiddleName = "Enrique",
                LastName = "Jimenez",
                SecondLastName = "Pimentel",
                Dob = new System.DateTime(1996, 06, 16),
                DocumentType = Core.Enums.DocumentType.ID,
                DocumentTypeValue = "22500851658",
                Gender = Core.Enums.Gender.MALE,
                UserName = "emma123",
                Password = "Hola1234"
            };

            var result = await _userService.UpdateAsync(id, requestDto);

            //Assert

            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requestDto.UserName, result.Entity.UserName);

        }

        [Fact]
        public async Task ShouldGetUserToken()
        {
            //Arrange

            var model = new AuthenticateRequestDto
            {
                UserName = "pedrord",
                Password = "Hola1234"
            };

            //Act

            var result = await _userService.GetToken(model);

            //Assert

            Assert.NotNull(result);
            Assert.IsType<AuthenticateResponseDto>(result);
            Assert.NotEmpty(result.Token);
            Assert.Equal(_Pedro.UserName, result.UserName);

        }
    }
}
