//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Domain.Common;
using Domain.Entities;
using Domain.Resources;

namespace Domain.Presistence.Interfaces;

public interface ITestRepository : IGenericRepository<Test>
{
    Task<QueryResult<Test>> GetPagedListAsync(TestQuery query, CancellationToken cancellationToken);
}
