using AutoMapper;
using Azure.Core;
using eCommerceServer_.Context;
using eCommerceServer_.Dtos;
using eCommerceServer_.DTOs;
using eCommerceServer_.Models;
using eCommerceServer_.Repositories;
using eCommerceServer_.Services;
using eCommerceServer_.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceServer_.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController : ControllerBase
{
	AppUserRepository appUserRepository;
	private readonly IMapper _mapper;
	IConfiguration _configuration;


    public AuthController(IMapper mapper, IConfiguration configuration)
    {
		_mapper = mapper;
		appUserRepository = new();
		_configuration = configuration;
	}

    [HttpPost] 
	public IActionResult Register(RegisterDto request)
	{
		//İş Kuralları
		//Requestion Validation Kuralları Check

		RegisterDtoValidator validator = new();
		ValidationResult result = validator.Validate(request);
		if (!result.IsValid)
		{	
			List<string> errorMessage = result.Errors.Select(s=> s.ErrorMessage).ToList();
			return BadRequest(errorMessage);
		}

		//if(request.FirstName == "" || request.FirstName == null)
		//{
		//	//throw new Exception(""Firstname cannot be empty or null"");
		//	return BadRequest(new {Message = "Firstname cannot be empty or null"});
		//}

		//if(string.IsNullOrEmpty(request.FirstName))
		//{
		//	return BadRequest(new { Message = "Firstname cannot be empty or null" });
		//}

		//if(request.FirstName.Length < 3 ) 
		//{
		//	throw new Exception("FirstName en az 3 karakter olmalıdır.");
		//}

		//if (string.IsNullOrEmpty(request.LastName))
		//{
		//	return BadRequest(new { Message = "LastName cannot be empty or null" });
		//}

		//if (request.LastName.Length < 3)
		//{
		//	throw new Exception("LastName en az 3 karakter olmalıdır.");
		//}

		//if (string.IsNullOrEmpty(request.Email))
		//{
		//	return BadRequest(new { Message = "LastName cannot be empty or null" });
		//}

		//if (request.Email.Length < 3)
		//{
		//	throw new Exception("LastName en az 3 karakter olmalıdır.");
		//}

		//if(!request.Email.Contains("@") || !request.Email.Contains(" "))
		//{
		//	return BadRequest(new { Message = "Geçerli bir mail adresi yazmalısınız." });
		//}

		//Loglamanın yapılması

		//Kaydın unique kontrolü

		


		bool isEmailExist = appUserRepository.isEmailExist(request.Email);
        if (isEmailExist)
        {
			return BadRequest(new { Message = "Email adresi daha önce kaydedilmiş." });
        }


		//Objenin oluşuturlması

		AppUser appUser = _mapper.Map<AppUser>(request);

  //      AppUser appUser = new()
		//{
		//	Firstname = request.FirstName,
		//	LastName = request.LastName,
		//	Email = request.Email,
		//	Password = request.Password
		//};


		//database kaydının yapılması
		appUserRepository.add(appUser);
		return NoContent();
	}

	[HttpPost]
	public IActionResult Login(LoginDto request)
	{
		//Validation Kontrolü

		LoginDtoValidator validator = new();
		ValidationResult result = validator.Validate(request);
		if (!result.IsValid)
		{
			List<string> errorMessages = result.Errors.Select(e=> e.ErrorMessage).ToList();
			return BadRequest(errorMessages);
		}
		//User Kontrolü

		AppUserRepository appUserRepository = new();
		AppUser? user = appUserRepository.Login(request.Email, request.Password);

		if (user is null)
		{
			return BadRequest(new { Message = "Kullanıcı bulunamadı." });
		}

		//Token - JWT ile token üreteceğiz.
		JwtProvider jwtProvider = new(_configuration);
		string token = jwtProvider.CreateToken(user);

		return Ok(new {AccessToken = token});
	}
}
