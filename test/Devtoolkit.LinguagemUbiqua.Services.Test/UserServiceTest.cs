﻿using AutoMapper;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Notifications;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Devtoolkit.LinguagemUbiqua.Domain.Extensions;
using Devtoolkit.LinguagemUbiqua.Domain.Specs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Devtoolkit.LinguagemUbiqua.Services.Test
{
    public class UserServiceTest
    {
        private string UserId = "1";
        private const string UserPassword = "1";
        private readonly Mock<IUserRepository> mockRepository = new();
        private readonly Mock<IMapper> mockMapper = new();
        private readonly Mock<INotifier> mockNotifier = new();
        private readonly UserEntity userEntity = new("joares");

        [Fact]
        public async void Delete_Success()
        {
            //Arrange
            SetupMockRepositoryForDelete(UserId, userEntity);
            UserService userService = new (mockRepository.Object, mockMapper.Object, mockNotifier.Object);

            //Act
            await userService.Delete(UserId);

            //Assert
            Assert.Equal(UserId, userEntity.Id);
        }

        [Theory(DisplayName = "Deletar usuario sem sucesso")]
        [InlineData("")]
        [InlineData(null)]
        public async void Delete_NotSuccess(string id)
        {
            //Arrange           
            SetupMockRepositoryForDelete(id, userEntity);
            UserService userService = new (mockRepository.Object, mockMapper.Object, mockNotifier.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Delete(id));
        }

        [Fact]
        public async void Find_Success()
        {
            //Arrange
            var localId = UserId;
            userEntity.Id = UserId;
            userEntity.SetPassword(UserPassword);
            UserDto moqDto = MoqUserDto(UserId);
            List<UserEntity> list = MoqListUserEntity(userEntity);

            mockRepository.Setup(x => x.Get(localId)).Returns(Task.FromResult(userEntity));
            mockMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);

            UserService userService = new(mockRepository.Object, mockMapper.Object, mockNotifier.Object);

            //Act
            var result = await userService.Find(UserId);

            //Assert
            Assert.Equal(userEntity.Id, result.Id);
            Assert.Equal(userEntity.Email, result.Email);
            Assert.Equal(userEntity.Password, result.Password);
        }

        [Theory(DisplayName = "Buscar contexto sem sucesso")]
        [InlineData("")]
        [InlineData(null)]
        public async void Find_NotSuccess(string id)
        {
            //Arrange
            SetupMockRepositoryForFind(id, userEntity);
            UserService userService = new (mockRepository.Object, mockMapper.Object, mockNotifier.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => userService.Find(id));
        }

        [Fact]
        public async Task GetAll_Success()
        {
            // Arrange
            SetupMockRepositoryForGetAll(userEntity);
            var expectedDto = MoqUserDto(UserId);
            mockMapper.Setup(m => m.Map<List<UserDto>>(It.IsAny<List<UserEntity>>())).Returns(new List<UserDto> { expectedDto });
            var userService = new UserService(mockRepository.Object, mockMapper.Object, mockNotifier.Object);

            // Act
            var result = (await userService.GetAll()).FirstOrDefault();

            // Assert
            AssertUserDtoEqualEntity(result, userEntity);
        }

        [Fact]
        public async void AddSuccess()
        {
            //Arrange
            UserId = " ";
            userEntity.Id = UserId;
            userEntity.SetPassword(UserPassword);
            UserDto moqDto = MoqUserDto(UserId);
            List<UserEntity> entities = new ();

            mockRepository.Setup(m => m.Get(UserEntitySpec.FindEntityByEmail(moqDto.Email))).Returns(Task.FromResult(entities));
            mockMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            mockMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);

            UserService userService = new (mockRepository.Object, mockMapper.Object, mockNotifier.Object);

            //Act
            await userService.AddOrUpdate(moqDto);

            //Assert
            //Assert
            Assert.Equal(UserId, moqDto.Id);
        }

        [Fact]
        public async void UpdateSuccess()
        {
            //Arrange
            userEntity.Id = UserId;
            userEntity.SetPassword(UserPassword);
            UserDto moqDto = MoqUserDto(UserId);

            mockMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            mockMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);

            UserService userService = new (mockRepository.Object, mockMapper.Object, mockNotifier.Object);

            //Act
            await userService.AddOrUpdate(moqDto);

            //Assert
            //Assert
            Assert.Equal(UserId, moqDto.Id);
        }

        [Fact]
        public async void AutenticateSuccess()
        {
            //Arrange
            UserId = "20";
            userEntity.Id = UserId;
            userEntity.SetPassword(UserPassword);
            List<UserEntity> list = MoqListUserEntity(userEntity);
            UserDto moqDto = MoqUserDto(UserId);

            mockMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            mockMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);
            mockRepository.Setup(x => x.Get(x => x.Email.Equals(moqDto.Email) && x.Password.Equals(moqDto.Password.Encrypt()))).Returns(Task.FromResult(list));

            UserService userService = new (mockRepository.Object, mockMapper.Object, mockNotifier.Object);

            //Act
            var result = await userService.Autenticate(moqDto);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async void Autenticate_NotSuccess()
        {
            //Arrange
            UserId = "20";
            Mock<INotifier> moqNotifier = new ();
            userEntity.Id = UserId;
            userEntity.SetPassword(UserPassword);
            List<UserEntity> list = new ();
            UserDto moqDto = MoqUserDto(UserId);

            mockMapper.Setup(m => m.Map<UserDto>(userEntity)).Returns(moqDto);
            mockMapper.Setup(m => m.Map<UserEntity>(moqDto)).Returns(userEntity);
            mockRepository.Setup(x => x.Get(x => x.Email.Equals(moqDto.Email) && x.Password.Equals(moqDto.Password.Encrypt()))).Returns(Task.FromResult(list));

            UserService userService = new (mockRepository.Object, mockMapper.Object, moqNotifier.Object);

            //Act
            var result = await userService.Autenticate(moqDto);

            //Assert
            Assert.False(result);
        }

        // Helper methods

        private void SetupMockRepositoryForDelete(string id, UserEntity entity)
        {
            entity.Id = id;
            entity.SetPassword(UserPassword);
            var list = MoqListUserEntity(entity);

            mockRepository.Setup(x => x.Get(x => x.Id.Equals(id))).ReturnsAsync(list);
            mockRepository.Setup(x => x.Remove(entity)).Returns(Task.CompletedTask);
        }

        private void SetupMockRepositoryForFind(string id, UserEntity entity)
        {
            entity.Id = id;
            entity.SetPassword(UserPassword);
            var list = MoqListUserEntity(entity);

            mockRepository.Setup(x => x.Get(x => x.Id.Equals(id))).ReturnsAsync(list);
        }

        private void SetupMockRepositoryForGetAll(UserEntity entity)
        {
            entity.Id = UserId;
            entity.SetPassword(UserPassword);
            var list = MoqListUserEntity(entity);

            mockRepository.Setup(x => x.Get()).ReturnsAsync(list);
        }

        private static UserDto MoqUserDto(string id)
        {
            return new UserDto()
            {
                Id = id,
                Password = UserPassword.Encrypt(),
                Email = "joares"
            };
        }

        private static List<UserEntity> MoqListUserEntity(UserEntity userEntity)
        {
            return new List<UserEntity>()
            {
                userEntity
            };
        }

        private static void AssertUserDtoEqualEntity(UserDto dto, UserEntity entity)
        {
            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.Email, dto.Email);
            Assert.Equal(entity.Password, dto.Password);
        }
    }
}
