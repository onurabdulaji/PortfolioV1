﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PortfolioV1.Application.Behaviours;
using PortfolioV1.Application.Validations;
using PortfolioV1.Application.Validations.HeroValidations;
using PortfolioV1.DTO.DTOs.HeroDtos;
using System.Reflection;

namespace PortfolioV1.Application.Extensions;
public static class FluentValidationExtensions
{
    public static void AddFluentValidationExtension(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddScoped<IValidatorService, ValidatorService>();

        services.AddScoped<IValidator<CreateHeroDto>, CreateHeroDtoValidator>();

    }
}