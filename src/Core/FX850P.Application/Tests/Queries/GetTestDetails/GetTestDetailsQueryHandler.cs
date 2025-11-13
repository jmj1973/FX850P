//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Tests.Dtos;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Tests.Queries.GetTestDetails;

public class GetTestDetailsQueryHandler : IApplicationRequestHandler<GetTestDetailsQuery, TestDto>
{
    private readonly ITestRepository _repository;
    private readonly IMapper _mapper;

    public GetTestDetailsQueryHandler(ITestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TestDto> Handle(GetTestDetailsQuery request, CancellationToken cancellationToken = default)
    {
        Domain.Entities.Test? test = await _repository.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (test is null)
        {
            throw new NotFoundException(nameof(test), request.Id);
        }

        return _mapper.Map<TestDto>(test);
    }
}
