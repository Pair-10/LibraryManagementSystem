﻿using NArchitecture.Core.Persistence.Repositories;
namespace Domain.Entities;

public class Ematerial : Entity<Guid>
{
    public Guid CategoryTypeId { get; set; }//
    public decimal Price { get; set; }//Fiyat
    public string PdfUrl { get; set; }
    //ilişki
    public virtual CategoryType? CategoryType { get; set; } = null;//Fk

    //Bir emetaryelin birden çok sepetemetaryeli olabilir
    public virtual ICollection<BasketEmaterial> BasketEmeterials { get; set; }
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

