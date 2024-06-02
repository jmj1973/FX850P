
namespace FX850P.Domain.Presistence.Interfaces
{
    public interface IQueryObject
    {
        public string SearchString { get; set; }
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
    }
}
