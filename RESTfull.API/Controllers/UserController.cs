using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain;
using RESTfull.Infrastructure;

namespace RESTfull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserRepository _userRepository;
        public UserController(Context context)
        {
            _context = context;
            _userRepository = new UserRepository(_context);
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserss()
        {
            //return await _context.Users.ToListAsync();
            return await _userRepository.GetAllAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            //var Users = await _context.Userss.FindAsync(id);
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            /*
            _context.Entry(Users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            */

            await _userRepository.UpdateAsync(user);

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User user)
        {
            //_context.Users.Add(Users);
            //await _context.SaveChangesAsync();
            await _userRepository.AddAsync(user);
            return CreatedAtAction("GetUsers", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            //var user = await _context.Users.FindAsync(id);
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            //_context.Users.Remove(Users);
            //await _context.SaveChangesAsync();
            await _userRepository.DeleteAsync(id);

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
