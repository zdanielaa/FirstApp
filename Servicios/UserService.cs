using FirstApp.Model;
using FirstApp.Repositories;


namespace FirstApp.Servicios
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> Get(int id);
        Task<User> CreateUser(String FirstName, String LastName, String UserName, String Password, String Email, String ProfilePhoto, String UserType);
        Task<User> UpdateUser(int UserId, String? FirstName = null, String? LastName = null, String? Password = null, String? Email = null, String? ProfilePhoto = null, String? UserType = null);
        Task<User> DeleteUser(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(string FirstName, string LastName, string UserName, string Password, string Email, string ProfilePhoto, string UserType)
        {
            return await _userRepository.CreateUser(FirstName, LastName, UserName, Password, Email, ProfilePhoto, UserType);
        }

        public async Task<User> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id); 
        }

        public async Task<User> Get(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> UpdateUser(int UserId, String? FirstName = null, String? LastName = null, String? Password = null, String? Email = null, String? ProfilePhoto = null, String? UserType = null)
        {
            User newUser = await _userRepository.Get(UserId);

            if (newUser != null)
            {
                if (FirstName != null) { newUser.FirstName = FirstName; }
                if (LastName != null) { newUser.LastName = LastName; }
                if (Password != null) { newUser.Password = Password; }
                if (Email != null) { newUser.Email = Email; }
                if (ProfilePhoto != null) { newUser.ProfilePhoto = ProfilePhoto; }
                if (UserType != null) { newUser.UserType = UserType; }
            }
            else { return null; }

            return await _userRepository.UpdateUser(newUser);
        }
    }
}
