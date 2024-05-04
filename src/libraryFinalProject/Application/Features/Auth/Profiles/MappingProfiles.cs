using Application.Features.Auth.Commands.RevokeToken;
using Application.Features.Penalties.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Auth.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<NArchitecture.Core.Security.Entities.RefreshToken<Guid>, RefreshToken>().ReverseMap();
        CreateMap<RefreshToken, RevokedTokenResponse>().ReverseMap();
        CreateMap<Penalty, GetByUserIdPenaltyResponse>().ReverseMap();//sonradan eklendi
    }
}
