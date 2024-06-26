using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using Application.Services.Activities;
using Application.Services.ActivityNotifications;
using Application.Services.Addresses;
using Application.Services.Articles;
using Application.Services.Authors;
using Application.Services.Baskets;
using Application.Services.BasketEmaterials;
using Application.Services.Books;
using Application.Services.BorrowedMaterials;
using Application.Services.Categories;
using Application.Services.CategoryTypes;
using Application.Services.Cities;
using Application.Services.Comments;
using Application.Services.Countries;
using Application.Services.Districts;
using Application.Services.Ematerials;
using Application.Services.EmaterialInvoices;
using Application.Services.Invoices;
using Application.Services.Locations;
using Application.Services.Magazines;
using Application.Services.Materials;
using Application.Services.MaterialAdvices;
using Application.Services.MaterialAuthors;
using Application.Services.MaterialLocations;
using Application.Services.MaterialPublishers;
using Application.Services.MaterialTranslators;
using Application.Services.Notifications;
using Application.Services.Orders;
using Application.Services.OrderEMaterials;
using Application.Services.Payments;
using Application.Services.PaymentTypes;
using Application.Services.Penalties;
using Application.Services.Publishers;
using Application.Services.Reservations;
using Application.Services.Streets;
using Application.Services.Surveys;
using Application.Services.Translators;
using Application.Services.UserActivities;
using Application.Services.UserAddresses;
using Application.Services.UserSurveys;
using Application.Services.MaterialTypes;
using Application.Services.Returneds;
using Application.Services.UserNotifications;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int>();

        services.AddScoped<IActivityService, ActivityManager>();
        services.AddScoped<IActivityNotificationService, ActivityNotificationManager>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IArticleService, ArticleManager>();
        services.AddScoped<IAuthorService, AuthorManager>();
        services.AddScoped<IBasketService, BasketManager>();
        services.AddScoped<IBasketEmaterialService, BasketEmaterialManager>();
        services.AddScoped<IBookService, BookManager>();
        services.AddScoped<IBorrowedMaterialService, BorrowedMaterialManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICategoryTypeService, CategoryTypeManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<ICommentService, CommentManager>();
        services.AddScoped<ICountryService, CountryManager>();
        services.AddScoped<IDistrictService, DistrictManager>();
        services.AddScoped<IEmaterialService, EmaterialManager>();
        services.AddScoped<IEmaterialInvoiceService, EmaterialInvoiceManager>();
        services.AddScoped<IInvoiceService, InvoiceManager>();
        services.AddScoped<ILocationService, LocationManager>();
        services.AddScoped<IMagazineService, MagazineManager>();
        services.AddScoped<IMaterialService, MaterialManager>();
        services.AddScoped<IMaterialAdviceService, MaterialAdviceManager>();
        services.AddScoped<IMaterialAuthorService, MaterialAuthorManager>();
        services.AddScoped<IMaterialLocationService, MaterialLocationManager>();
        services.AddScoped<IMaterialPublisherService, MaterialPublisherManager>();
        services.AddScoped<IMaterialTranslatorService, MaterialTranslatorManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IOrderEMaterialService, OrderEMaterialManager>();
        services.AddScoped<IPaymentService, PaymentManager>();
        services.AddScoped<IPaymentTypeService, PaymentTypeManager>();
        services.AddScoped<IPenaltyService, PenaltyManager>();
        services.AddScoped<IPublisherService, PublisherManager>();
        services.AddScoped<IReservationService, ReservationManager>();
        services.AddScoped<IStreetService, StreetManager>();
        services.AddScoped<ISurveyService, SurveyManager>();
        services.AddScoped<ITranslatorService, TranslatorManager>();
        services.AddScoped<IUserActivityService, UserActivityManager>();
        services.AddScoped<IUserAddressService, UserAddressManager>();
        services.AddScoped<IUserSurveyService, UserSurveyManager>();
        services.AddScoped<IMaterialTypeService, MaterialTypeManager>();
        services.AddScoped<IReturnedService, ReturnedManager>();
        services.AddScoped<IUserNotificationService, UserNotificationManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
