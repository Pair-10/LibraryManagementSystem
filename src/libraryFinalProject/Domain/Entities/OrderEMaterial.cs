using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities;

public class OrderEMaterial : Entity<Guid>
{
    public Guid EMaterialId { get; set; } // elektronik materyalin benzersiz kimliği
    public Guid OrderId { get; set; } // siparişin benzersiz kimliği
    public decimal QuantityPrice { get; set; } // birim başına fiyat
    public int Quantity { get; set; } // sipariş edilen miktar
    public decimal TotalPrice { get; set; } // toplam fiyat

    public virtual Order? Order { get; set; } = null;
    public virtual Ematerial? Ematerial { get; set; } = null;
    public OrderEMaterial()
    {
    }

    public OrderEMaterial(Guid eMaterialId, Guid orderId, decimal quantityPrice, int quantity, decimal totalPrice)
    {
        EMaterialId = eMaterialId;
        OrderId = orderId;
        QuantityPrice = quantityPrice;
        Quantity = quantity;
        TotalPrice = totalPrice;
    }
}
