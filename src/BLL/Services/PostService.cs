using AutoMapper;
using BLL.Abstractions;
using BLL.DTOs;
using DAL.Abstractions.UnitOfWork;
using DAL.Entities;

namespace BLL.Services;

public class PostService: IPostService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PostService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
        
    public async Task<PostDTO> AddAsync(PostDTO postDto)
    {
        var post = _mapper.Map<Post>(postDto);
        _unitOfWork.Posts.AddAsync(post);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<PostDTO>(post);
    }

    public async Task<IEnumerable<PostDTO>> GetAllAsync()
    {
        var posts = await _unitOfWork.Posts.GetAllAsync();
        var postDtos = _mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);
        return postDtos;
    }

    public async Task<PostDTO> GetByIdAsync(string id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        var postDto = _mapper.Map<PostDTO>(post);
        return postDto;
    }

    public async Task UpdateAsync(PostDTO postDto)
    {
        var post = _mapper.Map<Post>(postDto);
        _unitOfWork.Posts.Update(post);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveAsync(string id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        _unitOfWork.Posts.Remove(post);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<Post> GetPostByIdAsync(string id)
    {
        return await _unitOfWork.Posts.GetByIdAsync(id);
    }
}