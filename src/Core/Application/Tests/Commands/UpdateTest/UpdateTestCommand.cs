//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Application.Tests.Dtos;
using Application.Mediator.Contracts;
using Application.Common.Commands;

namespace Application.Tests.Commands.UpdateTest;

public class UpdateTestCommand : BaseAuditCommand, IApplicationRequest<TestDto>
{
    public int Id { get; set; }
}
