using Data.Entities;

namespace Data.Repository
{
    public class UserDBRepository : IUserDBRepository
    {
        private readonly ApplicationContext _context;
        public UserDBRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public User? Get(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}