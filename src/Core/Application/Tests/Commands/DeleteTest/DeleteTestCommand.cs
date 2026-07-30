//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Application.Common.Commands;
using Application.Mediator.Contracts;
using Application.Tests.Dtos;

namespace Application.Tests.Commands.DeleteTest;

public class DeleteTestCommand : BaseAuditCommand, IApplicationRequest<TestDto>
{
    public int Id { get; set; }
}
