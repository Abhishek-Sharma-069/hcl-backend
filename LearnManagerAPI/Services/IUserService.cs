using LearnManagerAPI.Models;

namespace LearnManagerAPI.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        User Createuser(User user);
        User UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}