﻿using Application.Helpers;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Persistence.Seed;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped(typeof(ILocalizerHelper<>), typeof(LocalizerHelper<>));
        services.AddScoped<IUserAccessor, UserAccessor>();
        return services;
    }
}