using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Reservations.Queries.GetList;

public class GetListReservationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid MaterialId { get; set; }
    public bool Status { get; set; }
}