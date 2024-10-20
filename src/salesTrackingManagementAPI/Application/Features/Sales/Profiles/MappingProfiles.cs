using Application.Features.Sales.Commands.Create;
using Application.Features.Sales.Commands.Delete;
using Application.Features.Sales.Commands.Update;
using Application.Features.Sales.Queries.GetById;
using Application.Features.Sales.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Sales.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Sale, CreateSaleCommand>().ReverseMap();
        CreateMap<Sale, CreatedSaleResponse>().ReverseMap();
        CreateMap<Sale, UpdateSaleCommand>().ReverseMap();
        CreateMap<Sale, UpdatedSaleResponse>().ReverseMap();
        CreateMap<Sale, DeleteSaleCommand>().ReverseMap();
        CreateMap<Sale, DeletedSaleResponse>().ReverseMap();
        CreateMap<Sale, GetByIdSaleResponse>().ReverseMap();
        CreateMap<Sale, GetListSaleListItemDto>().ReverseMap();
        CreateMap<IPaginate<Sale>, GetListResponse<GetListSaleListItemDto>>().ReverseMap();
    }
}