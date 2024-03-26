using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Activities.Constants;
using Application.Features.ActivityNotifications.Constants;
using Application.Features.Addresses.Constants;
using Application.Features.Articles.Constants;
using Application.Features.Authors.Constants;
using Application.Features.Baskets.Constants;
using Application.Features.BasketEmaterials.Constants;
using Application.Features.Books.Constants;
using Application.Features.BorrowedMaterials.Constants;
using Application.Features.Categories.Constants;
using Application.Features.CategoryTypes.Constants;
using Application.Features.Cities.Constants;
using Application.Features.Comments.Constants;
using Application.Features.Countries.Constants;
using Application.Features.Districts.Constants;
using Application.Features.Ematerials.Constants;
using Application.Features.EmaterialInvoices.Constants;
using Application.Features.Invoices.Constants;
using Application.Features.Locations.Constants;
using Application.Features.Magazines.Constants;
using Application.Features.Materials.Constants;
using Application.Features.MaterialAdvices.Constants;
using Application.Features.MaterialAuthors.Constants;
using Application.Features.MaterialLocations.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Activities
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ActivitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ActivitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = ActivitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = ActivitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = ActivitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = ActivitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ActivityNotifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ActivityNotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ActivityNotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = ActivityNotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = ActivityNotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = ActivityNotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = ActivityNotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Addresses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Articles
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ArticlesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ArticlesOperationClaims.Read },
                new() { Id = ++lastId, Name = ArticlesOperationClaims.Write },
                new() { Id = ++lastId, Name = ArticlesOperationClaims.Create },
                new() { Id = ++lastId, Name = ArticlesOperationClaims.Update },
                new() { Id = ++lastId, Name = ArticlesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Authors
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Baskets
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BasketsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BasketsOperationClaims.Read },
                new() { Id = ++lastId, Name = BasketsOperationClaims.Write },
                new() { Id = ++lastId, Name = BasketsOperationClaims.Create },
                new() { Id = ++lastId, Name = BasketsOperationClaims.Update },
                new() { Id = ++lastId, Name = BasketsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BasketEmaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BasketEmaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BasketEmaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BasketEmaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BasketEmaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BasketEmaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BasketEmaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Books
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BooksOperationClaims.Admin },
                new() { Id = ++lastId, Name = BooksOperationClaims.Read },
                new() { Id = ++lastId, Name = BooksOperationClaims.Write },
                new() { Id = ++lastId, Name = BooksOperationClaims.Create },
                new() { Id = ++lastId, Name = BooksOperationClaims.Update },
                new() { Id = ++lastId, Name = BooksOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BorrowedMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Categories
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CategoryTypes
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CategoryTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CategoryTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = CategoryTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = CategoryTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = CategoryTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = CategoryTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cities
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Comments
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CommentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Read },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Write },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Create },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Update },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Countries
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CountriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Districts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Read },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Write },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Create },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Update },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Ematerials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EmaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = EmaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = EmaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = EmaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = EmaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = EmaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region EmaterialInvoices
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = EmaterialInvoicesOperationClaims.Admin },
                new() { Id = ++lastId, Name = EmaterialInvoicesOperationClaims.Read },
                new() { Id = ++lastId, Name = EmaterialInvoicesOperationClaims.Write },
                new() { Id = ++lastId, Name = EmaterialInvoicesOperationClaims.Create },
                new() { Id = ++lastId, Name = EmaterialInvoicesOperationClaims.Update },
                new() { Id = ++lastId, Name = EmaterialInvoicesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Invoices
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Admin },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Read },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Write },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Create },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Update },
                new() { Id = ++lastId, Name = InvoicesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Locations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Magazines
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MagazinesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MagazinesOperationClaims.Read },
                new() { Id = ++lastId, Name = MagazinesOperationClaims.Write },
                new() { Id = ++lastId, Name = MagazinesOperationClaims.Create },
                new() { Id = ++lastId, Name = MagazinesOperationClaims.Update },
                new() { Id = ++lastId, Name = MagazinesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Materials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialAdvices
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialAdvicesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialAdvicesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialAdvicesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialAdvicesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialAdvicesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialAdvicesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialAuthors
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialAuthorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialAuthorsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialAuthorsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialAuthorsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialAuthorsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialAuthorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialLocations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialLocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialLocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialLocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialLocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialLocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialLocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
