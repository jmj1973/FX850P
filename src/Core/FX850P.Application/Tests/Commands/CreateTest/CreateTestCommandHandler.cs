//Paramter map for string format
// {0} <App>  
// {1} <Item> plural
// {2} <Item>
// {3} <Item> lowercase

using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FX850P.Application.Exceptions;
using FX850P.Application.Tests.Dtos;
using FX850P.Domain.Entities;
using FX850P.Domain.Presistence.Interfaces;

namespace FX850P.Application.Tests.Commands.CreateTest;

public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, TestDto>
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

    public async Task<TestDto> Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        // Validate
        var validator = new CreateTestCommandValidator();
        FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult.Errors);
        }

        /*
                    //Check if exist
                    var existingUser = await _repository.ExistAsync(u => u.UserName.ToUpper() == request.UserName.ToUpper());

                    if (existingUser)
                    {
                        throw new Exception($"Username '{request.UserName}' already exists.");
                    }

                    var existingEmail = await _userService.ExistAsync(u => u.Email.ToUpper() == request.Email.ToUpper());

                    if (existingUser)
                    {
                        throw new Exception($"Email '{request.Email}' already exists.");
                    }
        */
        // Add Test
        Test test = _mapper.Map<Test>(request);
        await _repository.AddAsync(test, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<TestDto>(test);
    }

}
