using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Business.Services;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;
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
    }
}
