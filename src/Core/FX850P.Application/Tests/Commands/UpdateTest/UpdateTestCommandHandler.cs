//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using FX850P.Application.Exceptions;
using FX850P.Application.Tests.Dtos;
using FX850P.Domain.Entities;
using FX850P.Domain.Presistence.Interfaces;
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Tests.Commands.UpdateTest;

public class UpdateTestCommandHandler : IApplicationRequestHandler<UpdateTestCommand, TestDto>
{
    private readonly ITestRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTestCommandHandler(ITestRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TestDto> Handle(UpdateTestCommand request, CancellationToken cancellationToken = default)
    {
        // Validation
        var validator = new UpdateTestCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken = default);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Check if exist
        Test? test = await _repository.FindUniqueAsync(u => u.Id == request.Id, cancellationToken);

        if (test is null)
        {
            throw new NotFoundException(nameof(test), request.Id);
        }

        test = request.ToEntity(test);

        await _unitOfWork.SaveAsync(cancellationToken);

        return test.ToDto();
    }
}
