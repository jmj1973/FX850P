using AutoMapper;
using FX850P.Application.Common.Dtos;
using FX850P.Domain.Common;

namespace FX850P.Application.Common.Profiles
{
    public class QueryProfile : Profile
    {
        public QueryProfile()
        {
            CreateMap(typeof(QueryResult<>), typeof(QueryResultDto<>));

            CreateMap<PageResult, PageResultDto>();
        }

    }
}
