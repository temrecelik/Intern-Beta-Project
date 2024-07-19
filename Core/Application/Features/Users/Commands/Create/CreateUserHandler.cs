using Application.Features.Users.Rules;
using Application.Repositories.UserRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Create;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    
    private readonly IMapper _mapper;
    private readonly IUserUnitOfWork _unitOfWork;
    private readonly IUserBusinessRules _BusinessRules;

	public CreateUserHandler(IMapper mapper, IUserUnitOfWork unitOfWork, IUserBusinessRules businessRules)
	{
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_BusinessRules = businessRules;
	}

	public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        await _BusinessRules.EmailAdressCannotBeExist(request.Email);

        var productWrite = _unitOfWork.WriteRepository;

        User user = _mapper.Map<User>(request);

        await _unitOfWork.WriteRepository.AddAsync(user);

		await _unitOfWork.SaveAsync();

		CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);

        return response;
    }
}