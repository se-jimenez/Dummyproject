using System;
using API.DTO;
using API.Entities;

namespace API.Interface;

public interface IUserRepository
{
    void Update(AppUser user);

    Task<bool> SaveAllAsync();

    Task<IEnumerable<AppUser>> GetUsersAsync();

    Task<AppUser?> GetUserByIdAsync(int id);

    Task<AppUser?> GetUserByUsernameAsync(string username);

    Task<IEnumerable<MemberDTO>> GetMembersAsync();

    Task<MemberDTO?> GetMemberAsync(string username);

}
