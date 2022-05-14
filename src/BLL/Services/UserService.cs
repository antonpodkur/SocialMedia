using AutoMapper;
using BLL.Abstractions;
using BLL.DTOs;
using DAL.Abstractions.UnitOfWork;
using DAL.Entities;

namespace BLL.Services;

public class UserService: IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<UserDTO> AddAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.CompleteAsync();
        return _mapper.Map<UserDTO>(user);

    }

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        var userDtos = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        return userDtos;

    }

    public async Task<UserDTO> GetByIdAsync(string id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        var userDto = _mapper.Map<UserDTO>(user);
        return userDto;
    }

    public async Task UpdateAsync(UserDTO userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _unitOfWork.Users.Update(user);
        await _unitOfWork.CompleteAsync();
    }

    public async Task RemoveAsync(string id)
    {
        var user = await GetUserByIdAsync(id);
        _unitOfWork.Users.Remove(user);
        await _unitOfWork.CompleteAsync();
    }


    public async Task<User> GetUserByIdAsync(string id)
    {
        return await _unitOfWork.Users.GetByIdAsync(id);
    }
}