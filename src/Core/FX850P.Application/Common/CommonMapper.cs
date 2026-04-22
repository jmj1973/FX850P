using FX850P.Application.Common.Dtos;
using FX850P.Domain.Common;

namespace FX850P.Application.Common;

public static class CommonMapper
{
    public static PageResultDto ToDto(this PageResult entity) => 
        new PageResultDto
        {
            Page = entity.Page,
            PageSize = entity.PageSize,
            TotalItems = entity.TotalItems
        };

    public static PageResult ToEntity(this PageResultDto dto) => 
        new PageResult
        {
            Page = dto.Page,
            PageSize = dto.PageSize,
            TotalItems = dto.TotalItems
        };

    public static QueryResultDto<TEntityDto> ToDto<TEntity, TEntityDto>(this QueryResult<TEntity> query, Func<TEntity, TEntityDto> mapFunc) => 
        new QueryResultDto<TEntityDto>
        {
            Page = query.Page.ToDto(),
            PageItems = query.PageItems.Select(mapFunc)
        };

    public static QueryResult<TEntity> ToEntity<TEntity, TEntityDto>(this QueryResultDto<TEntityDto> dto, Func<TEntityDto, TEntity> mapFunc) => 
        new QueryResult<TEntity>
        {
            Page = dto.Page.ToEntity(),
            PageItems = dto.PageItems.Select(mapFunc)
        };
}
