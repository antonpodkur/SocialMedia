using System.Security.Claims;
using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private IMapper _mapper;

    public UserController(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    [HttpGet("current")]
    public async Task<ActionResult<UserDTO>> GetCurrentUser()
    {
        var currentUserId = HttpContext.User.FindFirstValue("id");
        var currentUser = await _userManager.FindByIdAsync(currentUserId);
        return Ok(_mapper.Map<UserDTO>(currentUser));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return Ok(_mapper.Map<UserDTO>(user));

    }
    
    [HttpPut("updatecurrent")]
    public async Task<ActionResult<UserDTO>> UpdateCurrentUser (UserDTO updatedUser)
    {
        var user = await _userManager.FindByIdAsync(HttpContext.User.FindFirstValue("id"));
        user.UserName = updatedUser.Username;
        await _userManager.UpdateAsync(user);
        return Ok(_mapper.Map<UserDTO>(user));
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<UserDTO>> UpdateUserById(string id,UserDTO updatedUser)
    {
        var user = await _userManager.FindByIdAsync(id);
        user.UserName = updatedUser.Username;
        await _userManager.UpdateAsync(user);
        return Ok(_mapper.Map<UserDTO>(user));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return BadRequest();
        }

        await _userManager.DeleteAsync(user);
        return Ok();
    }
    
    

}