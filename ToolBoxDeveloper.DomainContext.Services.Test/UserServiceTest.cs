using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Business.Services;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Extensions;
using Xunit;

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
            Mock<ILogger<UserService>> logger = new Mock<ILogger<UserService>>();
            Mock<IUserRepository> moqRepository = new Mock<IUserRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            UserEntity userEntity = new UserEntity("joares");
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);

            List<UserEntity> list = new List<UserEntity>();
            list.Add(userEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(userEntity)).Returns(Task.CompletedTask);

            UserService userService = new UserService(moqRepository.Object,  moqMapper.Object, logger.Object);

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
            Mock<ILogger<UserService>> logger = new Mock<ILogger<UserService>>();
            Mock<IUserRepository> moqRepository = new Mock<IUserRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            UserEntity userEntity = new UserEntity("joares");
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);

            List<UserEntity> list = new List<UserEntity>();
            list.Add(userEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(userEntity)).Returns(Task.CompletedTask);

            UserService userService = new UserService(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Delete(id));
        }
        [Fact]
        public async void FindSuccess()
        {
            //Arrange
            string userPassword = "1";
            string id = "1";
            Mock<ILogger<UserService>> logger = new Mock<ILogger<UserService>>();
            Mock<IUserRepository> moqRepository = new Mock<IUserRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            UserEntity userEntity = new UserEntity("joares");
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);

            UserDto moqDto = new UserDto()
            {
                Id = id,
                Password= userPassword.Encrypt(),
                Email = "joares"
            };

            List<UserEntity> list = new List<UserEntity>();
            list.Add(userEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);

            UserService userService = new UserService(moqRepository.Object, moqMapper.Object, logger.Object);

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
            Mock<ILogger<UserService>> logger = new Mock<ILogger<UserService>>();
            Mock<IUserRepository> moqRepository = new Mock<IUserRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            UserEntity userEntity = new UserEntity("joares");
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);

            List<UserEntity> list = new List<UserEntity>();
            list.Add(userEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));

            UserService userService = new UserService(moqRepository.Object, moqMapper.Object, logger.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Find(id));
        }
    }
}
