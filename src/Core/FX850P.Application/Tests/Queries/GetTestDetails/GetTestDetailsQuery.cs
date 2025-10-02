//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using FX850P.Application.Mediator.Contracts;
using FX850P.Application.Tests.Dtos;

namespace FX850P.Application.Tests.Queries.GetTestDetails;

public class GetTestDetailsQuery : IApplicationRequest<TestDto>
{
    public int Id { get; set; }
}
