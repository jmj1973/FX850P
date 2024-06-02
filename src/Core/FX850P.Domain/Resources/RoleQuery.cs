using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Domain.Resources
{
    public class RoleQuery : IQueryObject
    {
        public string SearchString { get; set; } = default!;
        public string SortBy { get; set; } = default!;
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
