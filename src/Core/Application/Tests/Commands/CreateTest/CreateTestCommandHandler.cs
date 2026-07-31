//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using Application.Exceptions;
using Application.Tests.Dtos;
using Domain.Entities;
using Application.Mediator.Contracts;
using Domain.Persistence.Interfaces;

namespace Application.Tests.Commands.CreateTest;

public class CreateTestCommandHandler : IApplicationRequestHandler<CreateTestCommand, TestDto>
{
    private readonly ITestRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTestCommandHandler(ITestRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TestDto> Handle(CreateTestCommand request, CancellationToken cancellationToken = default)
    {
        // Validate
        var validator = new CreateTestCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Add Test
        Test test = request.ToEntity();
        await _repository.AddAsync(test, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return test.ToDto();
    }

}
