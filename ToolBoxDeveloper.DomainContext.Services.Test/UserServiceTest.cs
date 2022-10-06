using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;
using Xunit;

namespace ToolBoxDeveloper.DomainContext.Services.Test
{
    public  class UserServiceTest
    {
        string id = "1";
        string userPassword = "1";
        Mock<IUserRepository> moqRepository = new();
        Mock<IMapper> moqMapper = new();
        Mock<INotifier> moqNotifier = new();
        UserEntity userEntity = new("joares");      

        [Fact]
        public async void DeleteSuccess()
        {
            //Arrange
            var localId = id;
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            List<UserEntity> list = MoqListUserEntity(userEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(localId))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(userEntity)).Returns(Task.CompletedTask);

            UserService userService = new(moqRepository.Object,  moqMapper.Object,moqNotifier.Object);

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
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            List<UserEntity> list = MoqListUserEntity(userEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(userEntity)).Returns(Task.CompletedTask);

            UserService userService = new(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Delete(id));
        }

        [Fact]
        public async void FindSuccess()
        {
            //Arrange
            var localId = id;
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            UserDto moqDto = this.MoqUserDto(id);
            List<UserEntity> list = MoqListUserEntity(userEntity); 

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(localId))).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);

            UserService userService = new(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

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
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            List<UserEntity> list = MoqListUserEntity(userEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));

            UserService userService = new(moqRepository.Object, moqMapper.Object,  moqNotifier.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Find(id));
        }

        [Fact]
        public async void GetAllSuccess()
        {
            //Arrange
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            List<UserEntity> list = MoqListUserEntity(userEntity);
            UserDto moqDto = this.MoqUserDto(id);
            List<UserDto> listDto = MoqListUserDto(moqDto); 

            moqRepository.Setup(x => x.Get()).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<List<UserDto>>(list)).Returns(listDto);            

            UserService userService = new(moqRepository.Object, moqMapper.Object,  moqNotifier.Object);

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
            id = " ";
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            UserDto moqDto = this.MoqUserDto(id);
            List<UserEntity> entities = new();

            moqRepository.Setup(m => m.Get(x => x.Email.Equals(moqDto.Email))).Returns(Task.FromResult(entities));
            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            moqMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);

            UserService userService = new(moqRepository.Object, moqMapper.Object,moqNotifier.Object);

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
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            UserDto moqDto = this.MoqUserDto(id);

            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            moqMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);

            UserService userService = new(moqRepository.Object, moqMapper.Object,  moqNotifier.Object);

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
            id = "20";
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            List<UserEntity> list = MoqListUserEntity(userEntity);
            UserDto moqDto = this.MoqUserDto(id);

            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            moqMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);
            moqRepository.Setup(x => x.Get(x => x.Email.Equals(moqDto.Email) && x.Password.Equals(moqDto.Password.Encrypt()))).Returns(Task.FromResult(list));

            UserService userService = new(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            var result = await userService.Autenticate(moqDto);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async void AutenticateNotSuccess()
        {
            //Arrange
            id = "20";
            Mock<INotifier> moqNotifier = new();
            userEntity.Id = id;
            userEntity.SetPassword(userPassword);
            List<UserEntity> list = new();
            UserDto moqDto = this.MoqUserDto(id);

            moqMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            moqMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);
            moqRepository.Setup(x => x.Get(x => x.Email.Equals(moqDto.Email) && x.Password.Equals(moqDto.Password.Encrypt()))).Returns(Task.FromResult(list));

            UserService userService = new(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            var result = await userService.Autenticate(moqDto);

            //Assert
            Assert.False(result);
        }

        private static List<UserDto> MoqListUserDto(UserDto moqDto)
        {
            return new()
            {
                moqDto
            };
        }

        private static List<UserEntity> MoqListUserEntity(UserEntity userEntity)
        {
            return new()
            {
                userEntity
            };
        }

        private UserDto MoqUserDto(string id)
        {
            return new()
            {
                Id = id,
                Password = userPassword.Encrypt(),
                Email = "joares"
            };
        }
    }
}
