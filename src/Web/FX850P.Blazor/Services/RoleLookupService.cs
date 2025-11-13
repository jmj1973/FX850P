using System.Linq.Expressions;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Roles.Queries.GetRoleList;
using FX850P.Blazor.Contracts;
using FX850P.Blazor.ViewModels.CommonViewModels;

namespace FX850P.Blazor.Services;

public class RoleLookupService : IRoleLookupService
{
    private readonly IApplicationMediator _application;

    public RoleLookupService(IApplicationMediator application) => _application = application;

    public async Task<List<KeyValuePairViewModel<string>>> ListAsync()
    {
        var query = new GetRoleListQuery
        {
            SearchString = "",
            SortBy = "",
            IsSortAscending = true,
            Page = 1,
            PageSize = int.MaxValue
        };

        QueryResultDto<KeyValuePairDto<string>> result = await _application.Send< GetRoleListQuery, QueryResultDto<KeyValuePairDto<string>>>(query);

        var items = result.PageItems.AsQueryable().Select(_ToListViewModelSelector).ToList();

        items.Insert(0, new KeyValuePairViewModel<string>() { Id = "", Name = "" });

        return items;
    }

    #region Helpers

    private readonly Expression<Func<KeyValuePairDto<string>, KeyValuePairViewModel<string>>> _ToListViewModelSelector = (item) => new KeyValuePairViewModel<string>()
    {
        Id = item.Id,
        Name = item.Name,
    };
    #endregion

}
