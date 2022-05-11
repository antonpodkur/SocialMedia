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

    public Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserDTO userDto)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string id)
    {
        throw new NotImplementedException();
    }
}