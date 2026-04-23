using FX850P.Application.Tests.Commands.CreateTest;
using FX850P.Application.Tests.Commands.UpdateTest;
using FX850P.Application.Tests.Dtos;
using FX850P.Application.Tests.Queries.GetTestList;
using FX850P.Domain.Entities;
using FX850P.Domain.Resources;

namespace FX850P.Application.Tests;

public static class TestMapper
{
    public static TestDto ToDto(this Test entity) =>
        new TestDto
        {
            Id = entity.Id,
        };


#pragma warning disable IDE0060 // Remove unused parameter
    public static Test ToEntity(this CreateTestCommand command) =>
        new Test
        {
        };
    public static Test ToEntity(this CreateTestCommand command, Test entity) => entity;
#pragma warning restore IDE0060 // Remove unused parameter

    public static Test ToEntity(this UpdateTestCommand command, Test entity)
    {
        entity.Id = command.Id;
        return entity;
    }

    public static TestQuery ToEntity(this GetTestListQuery query) =>
        new TestQuery
        {
            SearchString = query.SearchString,
            SortBy = query.SortBy,
            IsSortAscending = query.IsSortAscending,
            Page = query.Page,
            PageSize = query.PageSize,
        };

}
