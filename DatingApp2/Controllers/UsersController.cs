using AutoMapper;
using DatingApp2.Data;
using DatingApp2.DTO;
using DatingApp2.Interfaces;
using DatingApp2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp2.Controllers
{

    [Authorize]
    public class UsersController : BaseApiController
    {
        //private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        //public UsersController(DataContext context)
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            //_context = context;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //[AllowAnonymous]
        //public ActionResult<IEnumerable<AppUser>> GetUsers() //List va anche bene al posto di IEnumerable, però offre operazioni aggiuntive (ordinare, manipolare...)
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetUsers()
        {
            //return await _context.Users.ToList();
            //return await _context.Users.ToListAsync();
            //return Ok(await _userRepository.GetUsersAsync());
            var users = await _userRepository.GetUsersAsync();
            //var usersToReturn = _mapper.Map<IEnumerable<MemberDTO>>(users);
            return Ok(users);
        }

        // api/users/2
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<MemberDTO>> GetUsers(string Username) //List va anche bene al posto di IEnumerable, però offre operazioni aggiuntive (ordinare, manipolare...)
        {
            //return await _userRepository.GetUserByNameAsync(Username);
            var user = await _userRepository.GetUserByNameAsync(Username);

            return _mapper.Map<MemberDTO>(user);
        }
    }
}
