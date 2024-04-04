using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MaterialType = Domain.Entities.MaterialType;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityNotification> ActivityNotifications { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketEmaterial> BasketEmaterials { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BorrowedMaterial> BorrowedMaterials { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryType> CategoryTypes { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Ematerial> Ematerials { get; set; }
    public DbSet<EmaterialInvoice> EmaterialInvoices { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Magazine> Magazines { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialAdvice> MaterialAdvices { get; set; }
    public DbSet<MaterialAuthor> MaterialAuthors { get; set; }
    public DbSet<MaterialLocation> MaterialLocations { get; set; }
    public DbSet<MaterialPublisher> MaterialPublishers { get; set; }
    public DbSet<MaterialTranslator> MaterialTranslators { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderEMaterial> OrderEMaterials { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Penalty> Penalties { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Returned> Returneds { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Translator> Translators { get; set; }
    public DbSet<MaterialType> Types { get; set; }
    public DbSet<UserActivity> UserActivities { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<UserSurvey> UserSurveys { get; set; }
    public DbSet<MaterialType> MaterialTypes { get; set; }
    public DbSet<UserNotification> UserNotifications { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Penalty>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<UserNotification>()
            .Property(un => un.Id)
            .ValueGeneratedOnAdd();
    }
}
