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
using FX850P.Application.Mediator.Contracts;

namespace FX850P.Application.Tests.Commands.CreateTest;

public class CreateTestCommandHandler : IApplicationRequestHandler<CreateTestCommand, TestDto>
{
    private readonly ITestRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTestCommandHandler(ITestRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
        Test test = _mapper.Map<Test>(request);
        await _repository.AddAsync(test, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<TestDto>(test);
    }

}
