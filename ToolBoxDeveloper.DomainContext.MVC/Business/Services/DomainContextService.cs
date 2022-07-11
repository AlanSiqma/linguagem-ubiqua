using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Dto;
using ToolBoxDeveloper.DomainContext.MVC.Domain.Entities;

namespace ToolBoxDeveloper.DomainContext.MVC.Business.Services
{
    public class DomainContextService: IDomainContextService
    {
        private readonly IDomainContextRepository _domainContextRepository;
        public DomainContextService(IDomainContextRepository domainContextRepository)
        {
            this._domainContextRepository = domainContextRepository;
        }

        public async Task AddOrUpdate(DomainContextDto dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
                 await Create(dto);
            else
                 await Update(dto);
        }
        private async Task<bool> Update(DomainContextDto dto)
        {
            var result = true;
            try
            {
                await this._domainContextRepository.Update(dto.Id, new DomainContextEntity().BuildDto(dto));
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        private async Task<bool> Create(DomainContextDto dto)
        {
            var result = true;
            try
            {            
                await this._domainContextRepository.Create(new DomainContextEntity().BuildDto(dto));
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = false;
            try
            {
                var entity = (await this._domainContextRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

                await this._domainContextRepository.Remove(entity);

                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<DomainContextDto> Find(string id)
        {
            DomainContextDto result;
            try
            {
                var entity = (await this._domainContextRepository.Get(x => x.Id.Equals(id))).FirstOrDefault();

                result = new DomainContextDto(entity);

            }
            catch (Exception)
            {
                result = new DomainContextDto();
            }

            return result;
        }

        public async Task<List<DomainContextDto>> GetAll()
        {
            List<DomainContextDto> result;
            try
            {
                var entities = await this._domainContextRepository.Get();
                result = entities.Select(x => new DomainContextDto(x)).ToList();
            }
            catch (Exception)
            {
                result = new List<DomainContextDto>();
            }

            return result;
        }
    }
}
