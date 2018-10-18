using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Dtos;
namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> Get();
        Task<UserDto> Get(string username);
        Task<UserDto> Login(LoginDto account);
        string Permission(int val);
    }
}
