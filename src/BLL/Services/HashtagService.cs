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

    public Task<IEnumerable<HashtagDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<HashtagDTO> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(HashtagDTO hashtagDTO)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Hashtag> GetHashtagByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
}