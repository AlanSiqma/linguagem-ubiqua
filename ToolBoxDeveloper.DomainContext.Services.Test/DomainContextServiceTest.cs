using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Business.Services;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;
using Xunit;

namespace ToolBoxDeveloper.DomainContext.Services.Test
{
    public class DomainContextServiceTest
    {
        [Fact]
        public async void DeleteSuccess()
        {
            //Arrange
            string idRemove = "1";
            Mock<ILogger<DomainContextService>> logger = new Mock<ILogger<DomainContextService>>();
            Mock<IDomainContextRepository> moqRepository = new Mock<IDomainContextRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();
            
            DomainContextEntity domainContextEntity = new DomainContextEntity("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            domainContextEntity.Id = idRemove;
            List<DomainContextEntity> list = new List<DomainContextEntity>();
            list.Add(domainContextEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idRemove))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(domainContextEntity)).Returns(Task.CompletedTask);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, logger.Object, moqMapper.Object);

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
            Mock<ILogger<DomainContextService>> logger = new Mock<ILogger<DomainContextService>>();
            Mock<IDomainContextRepository> moqRepository = new Mock<IDomainContextRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            DomainContextEntity domainContextEntity = new DomainContextEntity("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            domainContextEntity.Id = idRemove;
            List<DomainContextEntity> list = new List<DomainContextEntity>();
            list.Add(domainContextEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idRemove))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(domainContextEntity)).Returns(Task.CompletedTask);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, logger.Object, moqMapper.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>domainContextService.Delete(idRemove));
        }
        [Fact]
        public async void FindSuccess()
        {
            //Arrange
            string idFind = "1";
            Mock<ILogger<DomainContextService>> logger = new Mock<ILogger<DomainContextService>>();
            Mock<IDomainContextRepository> moqRepository = new Mock<IDomainContextRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            DomainContextEntity domainContextEntity = new DomainContextEntity("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            domainContextEntity.Id = idFind;
            DomainContextDto dtoMoq = new DomainContextDto("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            dtoMoq.Id = idFind;
            List<DomainContextEntity> list = new List<DomainContextEntity>();
            list.Add(domainContextEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idFind))).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<DomainContextDto>(domainContextEntity)).Returns(dtoMoq) ;

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, logger.Object, moqMapper.Object);

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
            Mock<ILogger<DomainContextService>> logger = new Mock<ILogger<DomainContextService>>();
            Mock<IDomainContextRepository> moqRepository = new Mock<IDomainContextRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            DomainContextEntity domainContextEntity = new DomainContextEntity("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            domainContextEntity.Id = idFind;
            DomainContextDto dtoMoq = new DomainContextDto("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            dtoMoq.Id = idFind;
            List<DomainContextEntity> list = new List<DomainContextEntity>();
            list.Add(domainContextEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idFind))).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<DomainContextDto>(domainContextEntity)).Returns(dtoMoq);


            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, logger.Object, moqMapper.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainContextService.Find(idFind));
        }

        [Fact]
        public async void GetAllSuccess()
        {
            //Arrange
            string idFind = "1";
            Mock<ILogger<DomainContextService>> logger = new Mock<ILogger<DomainContextService>>();
            Mock<IDomainContextRepository> moqRepository = new Mock<IDomainContextRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            DomainContextEntity domainContextEntity = new DomainContextEntity("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            domainContextEntity.Id = idFind;
            List<DomainContextEntity> list = new List<DomainContextEntity>();
            list.Add(domainContextEntity);

            DomainContextDto dtoMoq = new DomainContextDto("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares");
            dtoMoq.Id = idFind;
            List<DomainContextDto> listDto = new List<DomainContextDto>();
            listDto.Add(dtoMoq);

            moqRepository.Setup(x => x.Get()).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<List<DomainContextDto>>(list)).Returns(listDto);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, logger.Object, moqMapper.Object);

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
    }
}
