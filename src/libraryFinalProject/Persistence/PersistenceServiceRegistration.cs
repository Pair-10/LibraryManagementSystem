using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BaseDb")));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IActivityNotificationRepository, ActivityNotificationRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IBasketEmaterialRepository, BasketEmaterialRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBorrowedMaterialRepository, BorrowedMaterialRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryTypeRepository, CategoryTypeRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        return services;
    }
}
