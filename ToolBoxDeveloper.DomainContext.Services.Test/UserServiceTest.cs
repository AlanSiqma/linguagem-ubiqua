using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Services;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;
using Xunit;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;

namespace ToolBoxDeveloper.DomainContext.Services.Test
{
    public  class UserServiceTest
    {

        [Fact]
        public async void DeleteSuccess()
        {
            //Arrange
            string id = "1";
            string userPassword = "1";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity1 = new("joares");
            UserEntity userEntity = userEntity1;
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);

            List<UserEntity> list = new()
            {
                userEntity
            };

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(userEntity)).Returns(Task.CompletedTask);

            UserService userService = new(moqRepository.Object,  moqMapper.Object, logger.Object);

            //Act
            await userService.Delete(id);

            //Assert
            Assert.Equal(id, userEntity.Id);
        }

        [Theory(DisplayName = "Deletar usuario sem sucesso")]
        [InlineData("")]
        [InlineData(null)]
        public async void DeleteNotSuccess(string id)
        {
            //Arrange
            string userPassword = "1";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity = new("joares")
            {
                Id = id
            };
            userEntity.SetPassword(userPassword);

            List<UserEntity> list = new()
            {
                userEntity
            };

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(userEntity)).Returns(Task.CompletedTask);

            UserService userService = new(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Delete(id));
        }
        [Fact]
        public async void FindSuccess()
        {
            //Arrange
            string userPassword = "1";
            string id = "1";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity = new("joares")
            {
                Id = id
            };
            userEntity.SetPassword(userPassword);

            UserDto moqDto = new()
            {
                Id = id,
                Password= userPassword.Encrypt(),
                Email = "joares"
            };

            List<UserEntity> list = new()
            {
                userEntity
            };

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);

            UserService userService = new(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act
            var result = await userService.Find(id) ;

            //Assert
            Assert.Equal(userEntity.Id, result.Id);
            Assert.Equal(userEntity.Email, result.Email);
            Assert.Equal(userEntity.Password, result.Password);
        }

        [Theory(DisplayName = "Buscar contexto sem sucesso")]
        [InlineData("")]
        [InlineData(null)]
        public async void FindNotSuccess(string id)
        {
            //Arrange
            string userPassword = "1";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity = new("joares")
            {
                Id = id
            };
            userEntity.SetPassword(userPassword);

            List<UserEntity> list = new()
            {
                userEntity
            };

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));

            UserService userService = new(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Find(id));
        }
        [Fact]
        public async void GetAllSuccess()
        {
            //Arrange
            string userPassword = "1";
            string id = "1";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity = new("joares")
            {
                Id = id
            };
            userEntity.SetPassword(userPassword);
            List<UserEntity> list = new()
            {
                userEntity
            };

            UserDto moqDto = new()
            {
                Id = id,
                Password = userPassword.Encrypt(),
                Email = "joares"
            };
            List<UserDto> listDto = new()
            {
                moqDto
            };

            moqRepository.Setup(x => x.Get()).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<List<UserDto>>(list)).Returns(listDto);            

            UserService userService = new(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act
            var result = (await userService.GetAll()).FirstOrDefault();

            //Assert
            Assert.Equal(userEntity.Id, result.Id);
            Assert.Equal(userEntity.Email, result.Email);
            Assert.Equal(userEntity.Password, result.Password);
        }
        [Fact]
        public async void AddSuccess()
        {
            //Arrange
            string userPassword = "1";
            string id = " ";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity = new("joares")
            {
                Id = id
            };
            userEntity.SetPassword(userPassword);

            UserDto moqDto = new()
            {
                Id = id,
                Password = userPassword.Encrypt(),
                Email = "joares"
            };


            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            moqMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);

            UserService userService = new(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act
            await userService.AddOrUpdate(moqDto);

            //Assert
            //Assert
            Assert.Equal(id, moqDto.Id);
        }

        [Fact]
        public async void UpdateSuccess()
        {
            //Arrange
            string userPassword = "1";
            string id = "1";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity = new("joares")
            {
                Id = id
            };
            userEntity.SetPassword(userPassword);

            UserDto moqDto = new()
            {
                Id = id,
                Password = userPassword.Encrypt(),
                Email = "joares"
            };


            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            moqMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);

            UserService userService = new(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act
            await userService.AddOrUpdate(moqDto);

            //Assert
            //Assert
            Assert.Equal(id, moqDto.Id);
        }
        [Fact]
        public async void AutenticateSuccess()
        {
            //Arrange
            string userPassword = "1";
            string id = "20";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity = new("joares")
            {
                Id = id
            };
            userEntity.SetPassword(userPassword);

            var list = new List<UserEntity>
            {
                userEntity
            };

            UserDto moqDto = new()
            {
                Id = id,
                Password = userPassword,
                Email = "joares"
            };


            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            moqMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);
            moqRepository.Setup(x => x.Get(x => x.Email.Equals(moqDto.Email) && x.Password.Equals(moqDto.Password.Encrypt()))).Returns(Task.FromResult(list));

            UserService userService = new(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act
            var result = await userService.Autenticate(moqDto);

            //Assert
            Assert.True(result);
        }
        [Fact]
        public async void AutenticateNotSuccess()
        {
            //Arrange
            string userPassword = "1";
            string id = "20";
            Mock<ILogger<UserService>> logger = new();
            Mock<IUserRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();

            UserEntity userEntity = new("joares")
            {
                Id = id
            };
            userEntity.SetPassword(userPassword);

            var list = new List<UserEntity>();


            UserDto moqDto = new()
            {
                Id = id,
                Password = userPassword,
                Email = "joares"
            };

            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            moqMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);
            moqRepository.Setup(x => x.Get(x => x.Email.Equals(moqDto.Email) && x.Password.Equals(moqDto.Password.Encrypt()))).Returns(Task.FromResult(list));

            UserService userService = new(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act
            var result = await userService.Autenticate(moqDto);

            //Assert
            Assert.False(result);
        }
    }
}
