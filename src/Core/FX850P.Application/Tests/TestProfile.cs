//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using AutoMapper;
using FX850P.Application.Tests.Commands.CreateTest;
using FX850P.Application.Tests.Commands.UpdateTest;
using FX850P.Application.Tests.Dtos;
using FX850P.Application.Tests.Queries.GetTestList;
using FX850P.Domain.Entities;
using FX850P.Domain.Resources;

namespace FX850P.Core.Application.Tests;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<GetTestListQuery, TestQuery>();
        CreateMap<CreateTestCommand, Test>();
        CreateMap<UpdateTestCommand, Test>();
        CreateMap<Test, TestDto>();
    }
}
