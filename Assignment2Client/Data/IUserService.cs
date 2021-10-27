using System.Threading.Tasks;
using Assignment2Client.Data;

namespace Assignment2Client.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}