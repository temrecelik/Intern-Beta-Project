using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetAll;
using Application.Features.Users.Queries.GetById;
using Application.Repositories.UserRepository;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController<
    CreateUserRequest,
    UpdateUserRequest,
    DeleteUserRequest,
    GetByIdUserRequest,
    GetAllUserRequest,
    DeleteUserResponse,
    GetByIdUserResponse
>
{
  

    private readonly IUserUnitOfWork _unitOfWork;

    public UserController(
        IMediator mediator,
        IUserUnitOfWork unitOfWork,
        ILogger<UserController> logger) : base(logger, mediator)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost("SeedData")]
    public async Task<IActionResult> SeedData(int numberOfRecords)
    {

        for (int i = 1; i <= numberOfRecords; i = i + 1)
        {
            using (var hmac = new HMACSHA256())
            {
                var password = "123456";

                var user = new User
                {
                    Email = $"email{i}@mail.com",
                    PasswordSalt = hmac.Key, // Salt değeri
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), // Hash değeri
                    Name = $"User Name {i}",
                    Description = $"User Description {i}"
                };

                await _unitOfWork.WriteRepository.AddAsync(user);
            }
        }

        await _unitOfWork.SaveAsync();

        return Ok($"{numberOfRecords} User have been created.");
    }
}