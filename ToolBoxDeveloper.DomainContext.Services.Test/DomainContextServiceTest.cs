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
        [InlineData("asdasd")]
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
    }
}
