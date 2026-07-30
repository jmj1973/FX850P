//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Domain.Presistence.Interfaces;

namespace Domain.Resources;

public class TestQuery : IQueryObject
{
    public string SearchString { get; set; } = default!;
    public string SortBy { get; set; } = default!;
    public bool IsSortAscending { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

}
