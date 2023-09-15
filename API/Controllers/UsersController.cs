using API.Data;
using API.Entitites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() //This is our session with the database
        {
            var users = await _context.Users.ToListAsync(); // retrievces lsit of users

            return users;
        }

        //[Authorize] attribute - can only access if they ahve a jwt token

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) // retrieves a specific user by their ID
        {
            return await _context.Users.FindAsync(id);
        }
    }
}