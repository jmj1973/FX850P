using MediatR;
using FX850P.Application.Common.Dtos;
using FX850P.Application.Roles.Queries.GetRoleList;
using FX850P.Blazor.Contracts;
using FX850P.Blazor.ViewModels.CommonViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FX850P.Blazor.Services
{
    public class RoleLookupService : IRoleLookupService
    {
        private readonly IMediator _mediator;

        public RoleLookupService(IMediator mediator)
        {
            _mediator = mediator;
        }

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

            var result = await _mediator.Send(query);

            var items = result.PageItems.AsQueryable().Select(_ToListViewModelSelector).ToList();

            items.Insert(0, new KeyValuePairViewModel<string>() { Id = "", Name = "" });

            return items;
        }

        #region Helpers

        private Expression<Func<KeyValuePairDto<string>, KeyValuePairViewModel<string>>> _ToListViewModelSelector = (item) => new KeyValuePairViewModel<string>()
        {
            Id = item.Id,
            Name = item.Name,
        };
        #endregion

    }
}
