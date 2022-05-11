using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.AutoMapperProfiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, User>();
        CreateMap<User, UserDTO>();
    }
}