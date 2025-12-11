//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using FX850P.Domain.Common;
using FX850P.Domain.Entities;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Domain.Resources;
using FX850P.Presistence.Extensions;

namespace FX850P.Presistence.Repositories;

public class TestRepository : GenericRepository<Test>, ITestRepository
{
    private readonly ApplicationDBContext _context;
    public TestRepository(ApplicationDBContext context) : base(context) => _context = context;

    public async Task<QueryResult<Test>> GetPagedListAsync(TestQuery query, CancellationToken cancellationToken)
    {
        var queryResult = new QueryResult<Test>()
        {
            Page = new PageResult()
        };

        IQueryable<Test> queryDb = _context.Tests.AsQueryable();

        var columnsOrder = new Dictionary<string, Expression<Func<Test, object>>>
        {
            /*
            ["Id"] = x => x.Id,
            ["Number"] = x => x.Number,
            ["Description"] = x => x.Description,
            ["Price"] = x => x.Price,
            ["Onhand"] = x => x.Onhand,
            */
        };

        var columnsFilter = new Dictionary<bool, Expression<Func<Test, bool>>>
        {
            /*
            [!string.IsNullOrWhiteSpace(query.SearchString)] = x => x.Number.Contains(query.SearchString) ||
                                                                    x.Description.Contains(query.SearchString),
            */
        };

        queryDb = queryDb.ApplyFiltering(columnsFilter);

        queryResult.Page.TotalItems = await queryDb.CountAsync(cancellationToken);
        queryResult.Page.PageSize = query.PageSize;
        queryResult.Page.Page = query.Page;

        queryDb = queryDb.ApplyOrdering(query, columnsOrder);
        queryDb = queryDb.ApplyPaging(query);

        queryResult.PageItems = await queryDb.AsNoTracking()
                                                .ToListAsync(cancellationToken);
    
        return queryResult;
    }
}
