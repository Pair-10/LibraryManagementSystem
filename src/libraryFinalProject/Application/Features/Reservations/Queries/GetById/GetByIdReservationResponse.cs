using NArchitecture.Core.Application.Responses;

namespace Application.Features.Reservations.Queries.GetById;

public class GetByIdReservationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid MaterialId { get; set; }
    public bool Status { get; set; }
}