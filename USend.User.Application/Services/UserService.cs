using Mapster;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usend.UserApi.Domain.Entities;
using Usend.UserApi.Domain.Interfaces;
using USend.UserApi.Application.Dto;
using USend.UserApi.Application.Interfaces;

namespace USend.UserApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationContext _notification;
        private readonly IImageService _imageService;

        public UserService(
            IUnitOfWork unitOfWork,
            IImageService imageService,
            INotificationContext notification)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _notification = notification;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var usersDto = (await _unitOfWork
                                    .UserRepository
                                    .GetAllAsync())
                                    .Adapt<List<UserDto>>();

            foreach (var user in usersDto)
                user.ImageUrl = _imageService.FindImageUrl(user.CPF);

            return usersDto;
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = (await _unitOfWork
                            .UserRepository
                            .GetByEmailAsync(email))
                            .Adapt<UserDto>();

            if (user is null)
                return null;

            user.ImageUrl = _imageService.FindImageUrl(user.CPF);
            return user;
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = (await _unitOfWork
                            .UserRepository
                            .GetByIdAsync(id))
                            .Adapt<UserDto>();

            if (user is null)
                return null;

            user.ImageUrl = _imageService.FindImageUrl(user.CPF);
            return user;
        }

        public async void ChangeStatus(string email)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            if (user is null)
            {
                _notification.AddNotification("User not found!");
                return;
            }

            user.ChangeStatus();
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();
        }

        public async void Create(CreateUserDto createUserDto)
        {
            if (await UserExists(createUserDto))
            {
                _notification.AddNotification("CPF or email already registered!");
                return;
            }

            var user = createUserDto.Adapt<User>();
            _unitOfWork.UserRepository.Add(user);

            _imageService.WriteFileOnDisk(createUserDto.Image, user.CPF);
            if (_notification.HasNotifications)
                return;

            _unitOfWork.Commit();
        }              

        public async void Update(UpdateUserDto updateUserDto)
        {
            User user;
            if (!string.IsNullOrEmpty(updateUserDto.CPF))
                user = await _unitOfWork.UserRepository.GetByCPFAsync(updateUserDto.CPF);
            else
                user = await _unitOfWork.UserRepository.GetByEmailAsync(updateUserDto.Email);

            if (user is null)
            {
                _notification.AddNotification("User not found!");
                return;
            }
            
            if (!string.IsNullOrEmpty(updateUserDto.Image))
                _imageService.WriteFileOnDisk(updateUserDto.Image, user.CPF);

            if (_notification.HasNotifications)
                return;

            _unitOfWork.UserRepository.Update(updateUserDto.Adapt(user));
            _unitOfWork.Commit();
        }

        private async Task<bool> UserExists(CreateUserDto createUserDto)
        {
            if (await _unitOfWork.UserRepository.GetByCPFAsync(createUserDto.CPF) != null)
                return true;

            if (await _unitOfWork.UserRepository.GetByEmailAsync(createUserDto.Email) != null)
                return true;

            return false;
        }
    }
}
