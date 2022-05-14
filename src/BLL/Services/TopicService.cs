using AutoMapper;
using BLL.Abstractions;
using BLL.DTOs;
using DAL.Abstractions.UnitOfWork;
using DAL.Entities;

namespace BLL.Services;

public class TopicService: ITopicService
{

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TopicService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TopicDTO> AddAsync(TopicDTO topicDTO)
    {
        var topic = _mapper.Map<Topic>(topicDTO);
        _unitOfWork.Topics.AddAsync(topic);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<TopicDTO>(topic);

    }

    public async Task<IEnumerable<TopicDTO>> GetAllAsync()
    {
        var topics = await _unitOfWork.Topics.GetAllAsync();
        return _mapper.Map<IEnumerable<TopicDTO>>(topics);
    }

    public async Task<TopicDTO> GetByIdAsync(string id)
    {
        var topic = await _unitOfWork.Topics.GetByIdAsync(id);
        return _mapper.Map<TopicDTO>(topic);
    }

    public async Task UpdateAsync(TopicDTO topicDTO)
    {
        var topic = _mapper.Map<Topic>(topicDTO);
        _unitOfWork.Topics.Update(topic);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveAsync(string id)
    {
        var topic = await GetTopicByIdAsync(id);
        _unitOfWork.Topics.Remove(topic);
        await _unitOfWork.CompleteAsync();
    }
    
    public async Task<Topic> GetTopicByIdAsync(string id)
    {
        return await _unitOfWork.Topics.GetByIdAsync(id);
    }
}