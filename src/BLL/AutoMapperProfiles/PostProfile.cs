using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.AutoMapperProfiles;

public class PostProfile: Profile
{
    public PostProfile()
    {
        CreateMap<PostDTO, Post>();
        CreateMap<Post, PostDTO>();
    }
}