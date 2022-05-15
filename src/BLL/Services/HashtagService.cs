using AutoMapper;
using BLL.Abstractions;
using BLL.DTOs;
using DAL.Abstractions.UnitOfWork;
using DAL.Entities;

namespace BLL.Services;

public class HashtagService: IHashtagService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public HashtagService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<HashtagDTO> AddAsync(HashtagDTO hashtagDTO)
    {
        var hashtag = _mapper.Map<Hashtag>(hashtagDTO);
        _unitOfWork.Hashtags.AddAsync(hashtag);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<HashtagDTO>(hashtag);
    }

    public async Task<IEnumerable<HashtagDTO>> GetAllAsync()
    {
        var hashtags = await _unitOfWork.Hashtags.GetAllAsync();
        return _mapper.Map<IEnumerable<HashtagDTO>>(hashtags);
    }

    public async Task<HashtagDTO> GetByIdAsync(string id)
    {
        var hashtag = await _unitOfWork.Hashtags.GetByIdAsync(id);
        return _mapper.Map<HashtagDTO>(hashtag);
    }

    public async Task UpdateAsync(HashtagDTO hashtagDTO)
    {
        var hashtag = _mapper.Map<Hashtag>(hashtagDTO);
        _unitOfWork.Hashtags.Update(hashtag);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveAsync(string id)
    {
        var hashtag = await _unitOfWork.Hashtags.GetByIdAsync(id);
        _unitOfWork.Hashtags.Remove(hashtag);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<Hashtag> GetHashtagByIdAsync(string id)
    {
        return await _unitOfWork.Hashtags.GetByIdAsync(id);
    }
}