using TaskManagerApi.Models;

namespace TaskManagerApi.Services
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