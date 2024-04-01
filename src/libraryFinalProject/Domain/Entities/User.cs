namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public bool? PenaltyStatus { get; set; }
    //true ise işlem yapamasın.

    //ilişki kısmı

    // Bir kullanıcının birden fazla adresi olabilir
    public virtual ICollection<UserAddress>? UserAddresses { get; set; } = null;
    //Bir kullanıcının birden fazla materyal önerisi olabilir
    public virtual ICollection<MaterialAdvice>? MaterialAdvices { get; set; } = null;
    //Bir kullanıcının birden çok rezervasyonu olabilir 
    public virtual ICollection<Reservation>? Reservations { get; set; } = null;
    //Bir kullancının birden fazla yorumu olabilir
    public virtual ICollection<Comment>? Comments { get; set; } = null;
    //Bir kullancının birden fazla kullanıcıetkinliği olabilir 
    public virtual ICollection<UserActivity>? UserActivities { get; set; } = null;
    //Bir kullancının birden fazla kullanıcıanketi olabilir 
    public virtual ICollection<UserSurvey>? UserSurveys { get; set; } = null;
    //Bir kullanıcının birden fazla ödünç aldığı materyal olabilir
    public virtual ICollection<BorrowedMaterial>? BorrowedMaterials { get; set; } = null;
    //Bir kullanıcının birden fazla ödemesi olabilir
    public virtual ICollection<Payment>? Payments { get; set; } = null;

    //Bir kullanıcının bir adet sepeti olabilir 
    public virtual Basket? Basket { get; set; } = null;

    //sistemin kendi alanları-START
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;//bir kullanıcının birden çok işlem talebi olabilir one-to-many
    //kullanıcının oturumunun süresini uzatmak veya yeniden doğrulamak için
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;// bir kullanıcının birden çok yenileme anahtarı olabilir one-to-many
    //bir kullanıcının iki faktörlü kimlik doğrulama için tek kullanımlık şifreler (OTP) 
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!; //bir kullanıcının birden çok OTP doğrulayıcısı olabilir one-to-many
    // e-posta yoluyla kimlik doğrulamasını sağlayan nesneler
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;//bir kullanıcının birden çok e-posta doğrulayıcısı olabilir one-to-many
                                                                                                //sistemin kendi alanları-END

}
