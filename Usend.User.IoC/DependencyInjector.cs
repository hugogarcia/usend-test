using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usend.UserApi.Domain.Entities;
using Usend.UserApi.Domain.Interfaces;
using Usend.UserApi.Infrastructure.Contexts;
using Usend.UserApi.Infrastructure.UnitOfWork;
using USend.UserApi.Application.Dto;
using USend.UserApi.Application.Interfaces;
using USend.UserApi.Application.Notifications;
using USend.UserApi.Application.Services;
using USend.UserApi.Application.Validators;

namespace Usend.UserApi.IoC
{
    public static class DependencyInjector
    {
        public static void Inject(this IServiceCollection services)
        {
            services.AddDbContext<MainContext>(opt =>
                    opt.UseInMemoryDatabase(databaseName: "InMemoryDb"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
            services.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();
            services.AddScoped<IValidator<AuthenticationDto>, AuthenticationDtoValidator>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IAuthenticateService, AuthenticateService>();
        }

        public static void InitializeMemoryDatabase(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MainContext>();
            context.Add(new User
            {
                Name = "admin",
                Password = "123456789",
                CPF = "12345678912",
                Email = "admin@email.com"                
            });

            context.SaveChanges();
        }
    }
}
