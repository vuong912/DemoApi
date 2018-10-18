using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Helpers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApplication1.Dtos;
namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        DataContext db; IMapper mapper;
        public UserService(DataContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserDto>> Get()
        {
            return mapper.Map<List<UserDto>>(await db.Accounts.ToListAsync());
        }

        private async Task<Account> GetAccount(string username)
        {
            return await db.Accounts.FindAsync(username);
        }
        public async Task<UserDto> Get(string username)
        {
            Account acc = await GetAccount(username);
            if (acc == null)
                return null;
            return mapper.Map<UserDto>(acc);
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            Account acc = await GetAccount(loginDto.Username);
            if (loginDto.Password == acc.Password)
                return mapper.Map<UserDto>(acc);
            return null;
        }
        public string Permission(int val)
        {
            switch (val)
            {
                case 1:
                    return "Admin";
                case 2:
                    return "Manager";
                default:
                    return "None";
            }
        }
    }
}
