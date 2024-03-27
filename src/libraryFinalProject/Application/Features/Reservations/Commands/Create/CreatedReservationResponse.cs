using NArchitecture.Core.Application.Responses;

namespace Application.Features.Reservations.Commands.Create;

public class CreatedReservationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid MaterialId { get; set; }
    public DateTime ReservationDate { get; set; }
    public string Status { get; set; }
}