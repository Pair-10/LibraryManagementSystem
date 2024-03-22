using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;

public class Ematerial : Entity<Guid>
{
    public Guid CategoryTypeId { get; set; }//
    public decimal Price { get; set; }//Fiyat
    public string PdfUrl { get; set; }
    //ilişki
    public virtual CategoryType? CategoryType { get; set; } = null;//Fk
    public Ematerial()
    {
            
    }
    public Ematerial(Guid categoryTypeId, decimal price, string pdfUrl)
    {
        CategoryTypeId = categoryTypeId;
        Price = price;
        PdfUrl = pdfUrl;
    }
}

