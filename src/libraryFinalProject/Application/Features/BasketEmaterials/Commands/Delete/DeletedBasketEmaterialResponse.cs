using NArchitecture.Core.Application.Responses;

namespace Application.Features.BasketEmaterials.Commands.Delete;

public class DeletedBasketEmaterialResponse : IResponse
{
    public Guid Id { get; set; }
}