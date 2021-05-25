using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usend.UserApi.Domain.Entities;
using USend.UserApi.Application.Dto;

namespace USend.UserApi.Application.Interfaces
{
    public interface IUserService
    {
        void Create(CreateUserDto createUserDto);
        void Update(UpdateUserDto updateUserDto);
        void ChangeStatus(string email);
        Task<UserDto> GetById(Guid id);
        Task<UserDto> GetByEmail(string email);
        Task<List<UserDto>> GetAll();
    }
}
