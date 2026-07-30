//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Application.Mediator.Contracts;
using Application.Tests.Dtos;

namespace Application.Tests.Queries.GetTestDetails;

public class GetTestDetailsQuery : IApplicationRequest<TestDto>
{
    public int Id { get; set; }
}
