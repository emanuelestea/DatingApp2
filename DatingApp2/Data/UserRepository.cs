using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp2.DTO;
using DatingApp2.Helper;
using DatingApp2.Interfaces;
using DatingApp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatingApp2.Data
{
    public class UserRepository : IUserRepository
    {
        public readonly DataContext _context;

        public readonly IMapper _mapper;

        public UserRepository (DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberDTO> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.Username == username)
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

   
        public async Task<PagedList<MemberDTO>> GetMembersAsync(UserParams userParams)
        {
            var query = _context.Users.AsQueryable();

            query = query.Where(u => u.Username != userParams.CurrentUsername);
            query = query.Where(u => u.Gender == userParams.Gender);

            //var minDob = DateTime.FromOADate(DateTime.Today.AddYears(-userParams.MaxAge - 1));
            var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
            var maxDob = DateTime.Today.AddYears(-userParams.MinAge);
            //var query = _context.Users
            //    .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
            //    .AsNoTracking();
            query = query.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);

            query = userParams.OrderBy switch
            {
                "create" => query.OrderByDescending(u => u.Create),
                _ => query.OrderByDescending(u => u.LastActive)
            };
            
            return await PagedList<MemberDTO>.CreateAsync(query.AsNoTracking().ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                , userParams.PageNumber, userParams.PageSize);
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByNameAsync(string username)
        {
            return await _context.Users
                .Include(p => p.Photos) //necessario per ritrovare anche le foto
                .SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
