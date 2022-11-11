using Microsoft.EntityFrameworkCore;
using RESTfull.Domain;

namespace RESTfull.Infrastructure
{
    public class UsersRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public UsersRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Users>> GetAllAsync()
        {
            return await _context.Userss.OrderBy(p => p.FIO).ToListAsync();
            return await _context.Userss.OrderBy(p => p.City).ToListAsync();
            return await _context.Userss.OrderBy(p => p.Age).ToListAsync();
        }
        public async Task<Users> GetByIdAsync(int id)
        {
            return await _context.Userss.FindAsync(id);
        }
        public async Task AddAsync(Users Users)
        {
            _context.Userss.Add(Users);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Users Users)
        {
            var existUsers = await _context.Userss.FindAsync(Users.Id);
            _context.Entry(existUsers).CurrentValues.SetValues(Users);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Users Users = await _context.Userss.FindAsync(id);
            _context.Remove(Users);
            await _context.SaveChangesAsync();
        }
    }
}
