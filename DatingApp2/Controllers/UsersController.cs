using DatingApp2.Data;
using DatingApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //public ActionResult<IEnumerable<AppUser>> GetUsers() //List va anche bene al posto di IEnumerable, però offre operazioni aggiuntive (ordinare, manipolare...)
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //return await _context.Users.ToList();
            return await _context.Users.ToListAsync();
        }

        // api/users/2
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id) //List va anche bene al posto di IEnumerable, però offre operazioni aggiuntive (ordinare, manipolare...)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
