using Application.Features.Articles.Commands.Create;
using Application.Features.Articles.Commands.Delete;
using Application.Features.Articles.Commands.Update;
using Application.Features.Articles.Queries.GetById;
using Application.Features.Articles.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Articles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Article, CreateArticleCommand>().ReverseMap();
        CreateMap<Article, CreatedArticleResponse>().ReverseMap();
        CreateMap<Article, UpdateArticleCommand>().ReverseMap();
        CreateMap<Article, UpdatedArticleResponse>().ReverseMap();
        CreateMap<Article, DeleteArticleCommand>().ReverseMap();
        CreateMap<Article, DeletedArticleResponse>().ReverseMap();
        CreateMap<Article, GetByIdArticleResponse>().ReverseMap();
        CreateMap<Article, GetListArticleListItemDto>().ReverseMap();
        CreateMap<IPaginate<Article>, GetListResponse<GetListArticleListItemDto>>().ReverseMap();
    }
}