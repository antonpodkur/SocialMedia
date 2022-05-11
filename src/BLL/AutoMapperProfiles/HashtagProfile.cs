using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.AutoMapperProfiles;

public class HashtagProfile: Profile
{
    public HashtagProfile()
    {
        CreateMap<HashtagDTO, Hashtag>();
        CreateMap<Hashtag, HashtagDTO>();
    }
}