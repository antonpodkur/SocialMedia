using API.Configuration;
using API.Models.Request;
using API.Models.Response;
using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IMapper _mapper;

    public AuthController
    (
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<IdentityRole> roleManager,
        IOptionsMonitor<JwtConfiguration> optionsMonitor,
        TokenValidationParameters tokenValidationParameters,
        IMapper mapper
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwtConfiguration = optionsMonitor.CurrentValue;
        _tokenValidationParameters = tokenValidationParameters;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        var userExists = await _userManager.FindByEmailAsync(model.Email);
        if (userExists != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response(){ Status = "Error", Message = "User already exists!"});
        }

        User user = new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response(){Status = "Error", Message = "User creation failed. Check user details and try again."});
        }

        return Ok(new Response() { Status = "Success", Message = "User created successfully."});
    }

    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin(RegisterModel model)
    {
        var userExists = await _userManager.FindByEmailAsync(model.Email);
        if (userExists != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response() {Status = "Error", Message = "User already exists!"});
        }

        User user = new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };
        
        
    }

}