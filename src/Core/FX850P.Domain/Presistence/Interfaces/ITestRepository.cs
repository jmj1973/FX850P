//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using System.Threading;
using System.Threading.Tasks;
using FX850P.Domain.Common;
using FX850P.Domain.Entities;
using FX850P.Domain.Resources;

namespace FX850P.Domain.Presistence.Interfaces;

public interface ITestRepository : IGenericRepository<Test>
{
    Task<QueryResult<Test>> GetPagedListAsync(TestQuery query, CancellationToken cancellationToken);
}
