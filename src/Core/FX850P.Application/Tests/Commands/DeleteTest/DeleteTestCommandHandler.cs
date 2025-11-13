//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using AutoMapper;
using FX850P.Application.Exceptions;
using FX850P.Application.Tests.Dtos;
using FX850P.Domain.Entities;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Tests.Commands.DeleteTest;

public class DeleteTestCommandHandler : IApplicaionRequestHandler<DeleteTestCommand, TestDto>
{
    private readonly ITestRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteTestCommandHandler(ITestRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TestDto> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
    {
        // Check if exist
        Test? test = await _repository.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (test is null)
        {
            throw new NotFoundException(nameof(Test), request.Id);
        }

        _repository.Remove(test);
        await _unitOfWork.SaveAsync(cancellationToken);
        return _mapper.Map<TestDto>(test);
    }

}
