using Application.Tests.Commands.CreateTest;
using Application.Tests.Commands.UpdateTest;
using Application.Tests.Dtos;
using Application.Tests.Queries.GetTestList;
using Domain.Entities;
using Domain.Resources;

namespace Application.Tests;

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
