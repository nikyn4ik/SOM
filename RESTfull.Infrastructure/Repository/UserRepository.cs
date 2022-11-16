using Microsoft.EntityFrameworkCore;
using RESTfull.Domain;

namespace RESTfull.Infrastructure
{
    public class UserRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public UserRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.OrderBy(p => p.FIO).ToListAsync();
            //return await _context.Users.OrderBy(p => p.City).ToListAsync();
            //return await _context.Users.OrderBy(p => p.Age).ToListAsync();
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task AddAsync(User Users)
        {
            _context.Users.Add(Users);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            var existUsers = await _context.Users.FindAsync(user.Id);
            _context.Entry(existUsers).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            User user = await _context.Users.FindAsync(id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
