using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;
public class Material : Entity<Guid>
{
    public DateTime PublicationDate { get; set; } // Yayımlanma tarihi
    public string Language { get; set; } // Dil
    public int PageCount { get; set; } // Sayfa sayısı
    public bool Status { get; set; } // Durumu ( mevcut, ödünç verildi, kayıp gibi) bool olursa T/F (var mı yok mu durumu dönecek)
    public string MaterialName { get; set; } // Materyal adı
    public byte[]? MaterialImage { get; set; }//Materyal resmi
    public int Quantity { get; set; }//miktar
    //ilişki kısmı
    public virtual ICollection<MaterialPublisher>? MaterialPublishers { get; set; } = null;//Fk yayınevi tablosu ilişkisi
    public virtual ICollection<MaterialAuthor>? MaterialAuthors { get; set; } = null;//Fk yazar tablosu ilişkisi
    //Bir materyalin birden çok rezervasyonu  olabilir
    public virtual ICollection<Reservation>? Reservations { get; set; } = null;
    //Bir materyalin birden çok kategorituru olabilir
    public ICollection<CategoryType>?CategoryTypes { get; set; }=null;
    //Bir materyalin birden çok materyalçevirmeni olabilir
    public virtual ICollection<MaterialTranslator>? MaterialTranslators { get; set; } = null;
    //Bir materyalin  birden fazla yorumu olabilir
    public virtual ICollection<Comment>? Comments { get; set; } = null;
    //Bir materyalin birden fazla materyalkonumu olabilir
    public virtual ICollection<MaterialLocation>? MaterialLocations { get; set; } = null;
    //Bir materyalin birden fazla OduncAldıgiMetaryali olabilir
    public ICollection<BorrowedMaterial>? BorrowedMaterials { get; set; } = null;
    public Material()
    {
    }

    public Material(DateTime publicationDate, string language, 
        int pageCount, bool status, string materialName, byte[] materialImage, int quantity)
    {
        PublicationDate = publicationDate;
        Language = language;
        PageCount = pageCount;
        Status = status;
        MaterialName = materialName;
        Quantity = quantity;
        MaterialImage = materialImage;
    }
}