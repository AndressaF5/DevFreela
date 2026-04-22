using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Models;
using DevFreela.Application.Services;
using DevFreela.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddHandlers()
                .AddValidators();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

            services.AddScoped<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateUserValidator>();

            return services;
        }
    }
}