//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Application.Exceptions;
using Application.Tests.Dtos;
using Domain.Entities;
using Domain.Persistence.Interfaces;

namespace Application.Tests.Commands.DeleteTest;

public class DeleteTestCommandHandler : IApplicaionRequestHandler<DeleteTestCommand, TestDto>
{
    private readonly ITestRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTestCommandHandler(ITestRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TestDto> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
    {
        // Check if exist
        Test? test = await _repository.FindUniqueAsync(u => u.Id == request.Id, cancellationToken) ?? throw new NotFoundException(nameof(Test), request.Id);

        _repository.Remove(test);
        await _unitOfWork.SaveAsync(cancellationToken);
        return test.ToDto();
    }

}
