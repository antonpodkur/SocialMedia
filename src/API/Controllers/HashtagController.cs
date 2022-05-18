using BLL.Abstractions;
using BLL.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HashtagController : ControllerBase
{
    private readonly IHashtagService _hashtagService;
    public HashtagController(IHashtagService hashtagService)
    {
        _hashtagService = hashtagService;
    }
    
    [HttpPost("add/{postId}")]
    public async Task<IActionResult> AddHashtagToPost(string postId, HashtagDTO hashtagDto)
    {
        await _hashtagService.AddHashtagToPost(postId, hashtagDto);
        return Ok();
    }
    
    [HttpGet("{postId}")]
    public async Task<ActionResult<IEnumerable<HashtagDTO>>> GetPostHashtags(string postId)
    {
        var hashtags = await _hashtagService.GetPostHashtags(postId);
        return Ok(hashtags);
    }

    [HttpDelete("remove/{postId}/{hashtagId}")]
    public async Task<IActionResult> RemoveHashtagFromPost(string postId, string hashtagId)
    {
        await _hashtagService.RemoveHashtagFromPost(postId, hashtagId);
        return Ok();
    }
}