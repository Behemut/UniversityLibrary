using UniversityLibrary.Models;
namespace UniversityLibrary.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);

        bool UserExists(int Userid);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        bool Save();
    }
}
