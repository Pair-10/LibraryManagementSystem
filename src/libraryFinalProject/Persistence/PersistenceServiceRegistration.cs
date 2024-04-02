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
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IEmaterialRepository, EmaterialRepository>();
        services.AddScoped<IEmaterialInvoiceRepository, EmaterialInvoiceRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IMagazineRepository, MagazineRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IMaterialAdviceRepository, MaterialAdviceRepository>();
        services.AddScoped<IMaterialAuthorRepository, MaterialAuthorRepository>();
        services.AddScoped<IMaterialLocationRepository, MaterialLocationRepository>();
        services.AddScoped<IMaterialPublisherRepository, MaterialPublisherRepository>();
        services.AddScoped<IMaterialTranslatorRepository, MaterialTranslatorRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderEMaterialRepository, OrderEMaterialRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
        services.AddScoped<IPenaltyRepository, PenaltyRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IStreetRepository, StreetRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<ITranslatorRepository, TranslatorRepository>();
        services.AddScoped<IUserActivityRepository, UserActivityRepository>();
        services.AddScoped<IUserAddressRepository, UserAddressRepository>();
        services.AddScoped<IUserSurveyRepository, UserSurveyRepository>();
        services.AddScoped<IMaterialTypeRepository, MaterialTypeRepository>();
        services.AddScoped<IReturnedRepository, ReturnedRepository>();
        services.AddScoped<IUserNotificationRepository, UserNotificationRepository>();
        return services;
    }
}
