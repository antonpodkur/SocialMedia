using System.Security.Claims;
using AutoMapper;
using BLL.Abstractions;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("/api/[controller]")]
[ApiController]
[Authorize]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;

    public PostController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }

    [HttpGet("user-posts")]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetAllCurrentUserPosts()
    {
        var userId = HttpContext.User.FindFirstValue("id");
        var posts = await _postService.CurrentUserGetAllPosts(userId);
        return Ok(posts);
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<PostDTO>>> GetAll()
    {
        var posts = await _postService.GetAllAsync();
        return Ok(posts);
    }

    [HttpGet("{postId}")]
    public async Task<ActionResult<PostDTO>> GetById(string postId)
    {
        var post = await _postService.GetByIdAsync(postId);
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostDTO postDto)
    {
        await _postService.AddAsync(postDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(PostDTO postDto)
    {
        await _postService.UpdateAsync(postDto);
        return Ok();
    }

    [HttpDelete("{postId}")]
    public async Task<IActionResult> Delete(string postId)
    {
        await _postService.RemoveAsync(postId);
        return Ok();
    }
}