using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services
{
    public class UserService :IUserService
    {

        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new User { Id = 2, Name = "Bob", Email = "bob@example.com" },
            new User { Id = 3, Name = "Charlie", Email = "charlie@example.com" }
        };
        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUserById(int Id)
        {
            return _users.FirstOrDefault(u => u.Id == Id);
        }

        public User GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
        public User Createuser (User user)
        {
            user.Id = _users.Max(u=>u.Id) + 1;
            _users.Add(user);
            return user;
        }

        public User UpdateUser(int id, User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            return existingUser;
        }

        public void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}

