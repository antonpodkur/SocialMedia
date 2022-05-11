using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.AutoMapperProfiles;

public class TopicProfile: Profile
{
    public TopicProfile()
    {
        CreateMap<TopicDTO, Topic>();
        CreateMap<Topic, TopicDTO>();
    }
}