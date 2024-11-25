//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using AutoMapper;
using FX850P.Application.Tests.Commands.CreateTest;
using FX850P.Application.Tests.Commands.UpdateTest;
using FX850P.Application.Tests.Dtos;

namespace FX850P.Blazor.ViewModels.TestViewModels;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<TestDto, TestDetailViewModel>().ReverseMap();
        CreateMap<TestViewModel, CreateTestCommand>();
        CreateMap<TestDto, TestViewModel>();
        CreateMap<TestViewModel, UpdateTestCommand>();
    }
}
