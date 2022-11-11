using Microsoft.AspNetCore.Mvc;
using RESTfull.Domain;
using RESTfull.Infrastructure;

namespace RESTfull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;
        private readonly UsersRepository _UsersRepository;
        public UsersController(Context context)
        {
            _context = context;
            _UsersRepository = new UsersRepository(_context);
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUserss()
        {
            //return await _context.Userss.ToListAsync();
            return await _UsersRepository.GetAllAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            //var Users = await _context.Userss.FindAsync(id);
            var Users = await _UsersRepository.GetByIdAsync(id);
            if (Users == null)
            {
                return NotFound();
            }
            return Users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users Users)
        {
            if (id != Users.Id)
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

            await _UsersRepository.UpdateAsync(Users);

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users Users)
        {
            //_context.Userss.Add(Users);
            //await _context.SaveChangesAsync();
            await _UsersRepository.AddAsync(Users);
            return CreatedAtAction("GetUsers", new { id = Users.Id }, Users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            //var Users = await _context.Userss.FindAsync(id);
            var Users = await _UsersRepository.GetByIdAsync(id);
            if (Users == null)
            {
                return NotFound();
            }

            //_context.Userss.Remove(Users);
            //await _context.SaveChangesAsync();
            await _UsersRepository.DeleteAsync(id);

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.Userss.Any(e => e.Id == id);
        }
    }
}
