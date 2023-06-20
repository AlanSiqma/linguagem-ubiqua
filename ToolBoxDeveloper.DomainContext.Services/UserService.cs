using AutoMapper;
using System.Threading.Tasks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Notifications;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Repositories;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Services;
using ToolBoxDeveloper.DomainContext.Domain.Dto;
using ToolBoxDeveloper.DomainContext.Domain.Entities;
using ToolBoxDeveloper.DomainContext.Domain.Extensions;
using ToolBoxDeveloper.DomainContext.Domain.Specs;
using ToolBoxDeveloper.DomainContext.Services.Base;

namespace ToolBoxDeveloper.DomainContext.Services
{
    public class UserService : BaseService<UserEntity, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly INotifier _notifier;
        public UserService(IUserRepository repository, IMapper mapper, INotifier notifier) : base(repository, mapper, notifier)
        {
            this._userRepository = repository;
            this._mapper = mapper;
            this._notifier = notifier;
        }

        public async Task AddOrUpdate(UserDto dto)
        {
            if (dto.Id.IsNullOrEmptyOrWhiteSpace())
                await this.Create(dto);
            else
                await this.Update(dto);
        }

        public async Task<bool> Autenticate(UserDto dto)
        {
            var entity = await this._userRepository.Get(UserEntitySpec.Autenticate(dto));

            if (entity.Count > 0)
                return true;

            return false;
        }

        private async Task Update(UserDto dto)
        {
            UserEntity entity = _mapper.Map<UserEntity>(dto);

            entity.SetPassword(dto.Password);

            await this._userRepository.Update(dto.Id, entity);
        }

        private async Task Create(UserDto dto)
        {
            if (await this.EmailExists(dto))
                return;

            UserEntity entityMap = _mapper.Map<UserEntity>(dto);

            entityMap.SetPassword(dto.Password);

            await this._userRepository.Create(entityMap);
        }

        private async Task<bool> EmailExists(UserDto dto)
        {
            var entities = await this._userRepository.Get(UserEntitySpec.FindEntityByEmail(dto.Email));

            if (entities == null || entities.Count > 0)
            {
                this._notifier.Handle(new NotificationDto($"E-mail: {dto.Email}, já está cadastrado", true));
                return true;
            }

            return false;
        }
    }
}
