//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using FX850P.Application.Common.Commands;
using FX850P.Application.Tests.Dtos;
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Tests.Commands.UpdateTest;

public class UpdateTestCommand : BaseAuditCommand, IApplicationRequest<TestDto>
{
    public int Id { get; set; }
}
