//using Application.Features.Companies.Commands.Create;
//using Application.Features.Companies.Rules;
//using Application.Features.Orders.Commands.Create;
//using Application.Features.Users.Commands.Create;
//using Application.Features.Users.Rules;
//using Application.Repositories.CompanyRepository;
//using Application.Repositories.UserRepository;
//using Application.Tests.FakeDatas;
//using AutoMapper;
//using Domain.Entities;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Tests.Features.Users.Command
//{
//	public class CreateUserTest
//	{

//		private readonly Mock<IMapper> _mapperMock = new();
//		private readonly Mock<IUserUnitOfWork> _unitOfWorkMock = new();
//		private readonly Mock<IUserBusinessRules> _businessRulesMock = new();
//		private readonly CreateUserHandler _handler;
//		private readonly UserFakeData _fakeData = new();

//		public CreateUserTest()
//		{
//			_handler = new CreateUserHandler(_mapperMock.Object, _unitOfWorkMock.Object, _businessRulesMock.Object);
//		}

//	}




//	[Fact]
//	public async Task CreateUserHandler_GivenUserToCreate_ShouldReturnSuccessfulUserModel()
//	{
//		CreateUserRequest request = new()
//		{
//			Name = "test",
//			Description = "test",
//			Email = "test"

//		};
		
//		var response = new CreateOrderResponse
//		{
			
//			Name = request.Name,
			
//		};



//	}


//}