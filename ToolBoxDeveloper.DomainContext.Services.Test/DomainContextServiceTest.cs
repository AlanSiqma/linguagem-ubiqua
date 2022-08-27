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
using Xunit;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;

namespace ToolBoxDeveloper.DomainContext.Services.Test
{
    public class DomainContextServiceTest
    {
        [Fact]
        public async void DeleteSuccess()
        {
            //Arrange
            string idRemove = "1";
            Mock<ILogger<DomainContextService>> logger = new();
            Mock<IDomainContextRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();
            Mock<INotifier> moqNotifier = new();

            DomainContextEntity domainContextEntity = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idRemove
            };
            List<DomainContextEntity> list = new()
            {
                domainContextEntity
            };

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idRemove))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(domainContextEntity)).Returns(Task.CompletedTask);

            DomainContextService domainContextService = new(moqRepository.Object, logger.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            await domainContextService.Delete(idRemove);

            //Assert
            Assert.Equal(idRemove, domainContextEntity.Id);
        }

        [Theory(DisplayName = "Deletar contexto sem sucesso")]
        [InlineData("")]
        [InlineData(null)]
        public async void DeleteNotSuccess(string idRemove)
        {
            //Arrange
            Mock<ILogger<DomainContextService>> logger = new();
            Mock<IDomainContextRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();
            Mock<INotifier> moqNotifier = new();

            DomainContextEntity domainContextEntity = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idRemove
            };
            List<DomainContextEntity> list = new()
            {
                domainContextEntity
            };

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idRemove))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(domainContextEntity)).Returns(Task.CompletedTask);

            DomainContextService domainContextService = new(moqRepository.Object, logger.Object, moqMapper.Object, moqNotifier.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainContextService.Delete(idRemove));
        }
        [Fact]
        public async void FindSuccess()
        {
            //Arrange
            string idFind = "1";
            Mock<ILogger<DomainContextService>> logger = new();
            Mock<IDomainContextRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();
            Mock<INotifier> moqNotifier = new();

            DomainContextEntity domainContextEntity = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };
            DomainContextDto dtoMoq = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };
            List<DomainContextEntity> list = new()
            {
                domainContextEntity
            };

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idFind))).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<DomainContextDto>(domainContextEntity)).Returns(dtoMoq);

            DomainContextService domainContextService = new(moqRepository.Object, logger.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            DomainContextDto result = await domainContextService.Find(idFind);

            //Assert
            Assert.Equal(domainContextEntity.Id, result.Id);
            Assert.Equal(domainContextEntity.Context, result.Context);
            Assert.Equal(domainContextEntity.Organization, result.Organization);
            Assert.Equal(domainContextEntity.Domain, result.Domain);
            Assert.Equal(domainContextEntity.Key, result.Key);
            Assert.Equal(domainContextEntity.Description, result.Description);
            Assert.Equal(domainContextEntity.UserRegister, result.UserRegister);
        }

        [Theory(DisplayName = "Buscar contexto sem sucesso")]
        [InlineData("")]
        [InlineData(null)]
        public async void FindNotSuccess(string idFind)
        {
            //Arrange
            Mock<ILogger<DomainContextService>> logger = new();
            Mock<IDomainContextRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();
            Mock<INotifier> moqNotifier = new();

            DomainContextEntity domainContextEntity = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };
            DomainContextDto dtoMoq = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };
            List<DomainContextEntity> list = new()
            {
                domainContextEntity
            };

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idFind))).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<DomainContextDto>(domainContextEntity)).Returns(dtoMoq);


            DomainContextService domainContextService = new(moqRepository.Object, logger.Object, moqMapper.Object, moqNotifier.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainContextService.Find(idFind));
        }

        [Fact]
        public async void GetAllSuccess()
        {
            //Arrange
            string idFind = "1";
            Mock<ILogger<DomainContextService>> logger = new();
            Mock<IDomainContextRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();
            Mock<INotifier> moqNotifier = new();

            DomainContextEntity domainContextEntity = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };
            List<DomainContextEntity> list = new()
            {
                domainContextEntity
            };

            DomainContextDto dtoMoq = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };
            List<DomainContextDto> listDto = new()
            {
                dtoMoq
            };

            moqRepository.Setup(x => x.Get()).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<List<DomainContextDto>>(list)).Returns(listDto);

            DomainContextService domainContextService = new(moqRepository.Object, logger.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            DomainContextDto result = (await domainContextService.GetAll()).FirstOrDefault();

            //Assert
            Assert.Equal(domainContextEntity.Id, result.Id);
            Assert.Equal(domainContextEntity.Context, result.Context);
            Assert.Equal(domainContextEntity.Organization, result.Organization);
            Assert.Equal(domainContextEntity.Domain, result.Domain);
            Assert.Equal(domainContextEntity.Key, result.Key);
            Assert.Equal(domainContextEntity.Description, result.Description);
            Assert.Equal(domainContextEntity.UserRegister, result.UserRegister);
        }
        [Fact]
        public async void AddSuccess()
        {
            //Arrange
            Mock<ILogger<DomainContextService>> logger = new();
            Mock<IDomainContextRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();
            Mock<INotifier> moqNotifier = new();

            string idFind = " ";

            DomainContextEntity domainContextEntity = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };

            DomainContextDto dtoMoq = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };


            moqMapper.Setup(m => m.Map<DomainContextEntity>(dtoMoq)).Returns(domainContextEntity);

            DomainContextService domainContextService = new(moqRepository.Object, logger.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            await domainContextService.AddOrUpdate(dtoMoq);

            //Assert
            //Assert
            Assert.Equal(idFind, dtoMoq.Id);
        }

        [Fact]
        public async void UpdateSuccess()
        {
            //Arrange
            Mock<ILogger<DomainContextService>> logger = new();
            Mock<IDomainContextRepository> moqRepository = new();
            Mock<IMapper> moqMapper = new();
            Mock<INotifier> moqNotifier = new();

            string idFind = "1";

            DomainContextEntity domainContextEntity = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };

            DomainContextDto dtoMoq = new("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = idFind
            };


            moqMapper.Setup(m => m.Map<DomainContextEntity>(dtoMoq)).Returns(domainContextEntity);

            DomainContextService domainContextService = new(moqRepository.Object, logger.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            await domainContextService.AddOrUpdate(dtoMoq);

            //Assert
            //Assert
            Assert.Equal(idFind, dtoMoq.Id);
        }
    }
}
