using BLL.Abstractions;
using BLL.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicController : ControllerBase
{
    private readonly ITopicService _topicService;
    public TopicController(ITopicService topicService)
    {
        _topicService = topicService;
    }
    
    [HttpPost("add/{postId}")]
    public async Task<IActionResult> AddTopicToPost(string postId, TopicDTO topicDto)
    {
        await _topicService.AddTopicToPost(postId, topicDto);
        return Ok();
    }
    
    [HttpGet("{postId}")]
    public async Task<ActionResult<IEnumerable<TopicDTO>>> GetPostTopics(string postId)
    {
        var topics = await _topicService.GetPostTopics(postId);
        return Ok(topics);
    }

    [HttpDelete("remove/{postId}/{topicId}")]
    public async Task<IActionResult> RemoveTopicFromPost(string postId, string topicId)
    {
        await _topicService.RemoveTopicFromPost(postId, topicId);
        return Ok();
    }
}