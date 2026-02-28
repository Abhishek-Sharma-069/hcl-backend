using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(long id);
        User GetUserByEmail(string email);
        User Createuser(User user);
        User UpdateUser(long id, User user);
        void DeleteUser(long id);
    }
}