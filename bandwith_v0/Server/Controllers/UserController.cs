using Microsoft.AspNetCore.Mvc;
using bandwith_v0.Server;
using bandwith_v0.Shared;
using bandwith_v0.Client.Shared;

namespace bandwith_v0.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // Other actions (GetUser, PutUser, DeleteUser, etc.) can go here
    }
}
