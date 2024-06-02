using FX850P.Application.Common.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using MediatR;

namespace FX850P.Application.Roles.Queries.GetRoleList
{
    public class GetRoleListQuery : IRequest<QueryResultDto<KeyValuePairDto<string>>>, IQueryObject
    {   
        public string SearchString { get; set; } = default!;
        public string SortBy { get; set; } = default!;
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
