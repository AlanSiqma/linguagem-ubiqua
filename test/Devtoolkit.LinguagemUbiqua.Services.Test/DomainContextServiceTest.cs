using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Notifications;
using Devtoolkit.LinguagemUbiqua.Domain.Contracts.Repositories;
using Devtoolkit.LinguagemUbiqua.Domain.Dto;
using Devtoolkit.LinguagemUbiqua.Domain.Entities;
using Xunit;

namespace Devtoolkit.LinguagemUbiqua.Services.Test
{
    public class DomainContextServiceTest
    {
        string id = "1";
        readonly Mock<IDomainContextRepository> moqRepository = new Mock<IDomainContextRepository>();
        readonly Mock<IMapper> moqMapper = new Mock<IMapper>();
        readonly Mock<INotifier> moqNotifier = new Mock<INotifier>();
        [Fact]
        public async void DeleteSuccess()
        {
            //Arrange
            var id = this.id;
            DomainContextEntity domainContextEntity = MoqDomainContextEntity(this.id);
            List<DomainContextEntity> list = MoqListDomainContextEntity(domainContextEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(id))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(domainContextEntity)).Returns(Task.CompletedTask);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            await domainContextService.Delete(this.id);

            //Assert
            Assert.Equal(this.id, domainContextEntity.Id);
        }

        [Theory(DisplayName = "Deletar contexto sem sucesso")]
        [InlineData("")]
        [InlineData(null)]
        public async void DeleteNotSuccess(string idRemove)
        {
            //Arrange       
            DomainContextEntity domainContextEntity = MoqDomainContextEntity(idRemove);
            List<DomainContextEntity> list = MoqListDomainContextEntity(domainContextEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idRemove))).Returns(Task.FromResult(list));
            moqRepository.Setup(x => x.Remove(domainContextEntity)).Returns(Task.CompletedTask);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainContextService.Delete(idRemove));
        }
        [Fact]
        public async void FindSuccess()
        {
            //Arrange
            var id = this.id;
            DomainContextEntity domainContextEntity = MoqDomainContextEntity(this.id);
            DomainContextDto dtoMoq = MoqDomainContextDto(this.id);

            moqRepository.Setup(x => x.Get(id)).Returns(Task.FromResult(domainContextEntity));
            moqMapper.Setup(m => m.Map<DomainContextDto>(domainContextEntity)).Returns(dtoMoq);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            DomainContextDto result = await domainContextService.Find(this.id);

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
            DomainContextEntity domainContextEntity = MoqDomainContextEntity(idFind);
            DomainContextDto dtoMoq = MoqDomainContextDto(idFind);
            List<DomainContextEntity> list = MoqListDomainContextEntity(domainContextEntity);

            moqRepository.Setup(x => x.Get(x => x.Id.Equals(idFind))).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<DomainContextDto>(domainContextEntity)).Returns(dtoMoq);


            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act &&  Assert
            await Assert.ThrowsAsync<ArgumentException>(() => domainContextService.Find(idFind));
        }

        [Fact]
        public async void GetAllSuccess()
        {
            //Arrange
            DomainContextEntity domainContextEntity = MoqDomainContextEntity(this.id);
            List<DomainContextEntity> list = MoqListDomainContextEntity(domainContextEntity);
            DomainContextDto dtoMoq = MoqDomainContextDto(this.id);
            List<DomainContextDto> listDto = MoqListDomainContextDto(dtoMoq);

            moqRepository.Setup(x => x.Get()).Returns(Task.FromResult(list));
            moqMapper.Setup(m => m.Map<List<DomainContextDto>>(list)).Returns(listDto);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

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
            this.id = " ";
            DomainContextEntity domainContextEntity = MoqDomainContextEntity(this.id);
            DomainContextDto dtoMoq = MoqDomainContextDto(this.id);

            moqMapper.Setup(m => m.Map<DomainContextEntity>(dtoMoq)).Returns(domainContextEntity);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            await domainContextService.AddOrUpdate(dtoMoq);

            //Assert
            //Assert
            Assert.Equal(this.id, dtoMoq.Id);
        }

        [Fact]
        public async void UpdateSuccess()
        {
            //Arrange           
            DomainContextEntity domainContextEntity = MoqDomainContextEntity(this.id);
            DomainContextDto dtoMoq = MoqDomainContextDto(this.id);

            moqMapper.Setup(m => m.Map<DomainContextEntity>(dtoMoq)).Returns(domainContextEntity);

            DomainContextService domainContextService = new DomainContextService(moqRepository.Object, moqMapper.Object, moqNotifier.Object);

            //Act
            await domainContextService.AddOrUpdate(dtoMoq);

            //Assert
            Assert.Equal(this.id, dtoMoq.Id);
        }

        private static DomainContextEntity MoqDomainContextEntity(string id)
        {
            return new DomainContextEntity("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = id
            };
        }

        private static DomainContextDto MoqDomainContextDto(string id)
        {
            return new DomainContextDto("ToolBoDevelopr", "DomainContext", "Teste1", "Teste1", "Teste unitario", "joares")
            {
                Id = id
            };
        }
        private static List<DomainContextEntity> MoqListDomainContextEntity(DomainContextEntity entity)
        {
            return new List<DomainContextEntity>()
            {
                entity
            };
        }
        private static List<DomainContextDto> MoqListDomainContextDto(DomainContextDto dto)
        {
            return new List<DomainContextDto>()
            {
                dto
            };
        }
    }
}
