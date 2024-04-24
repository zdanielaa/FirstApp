using FirstApp.Context;
using FirstApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> Get(int id);
        Task<User> CreateUser(String FirstName, String LastName, String UserName, String Password, String Email, String ProfilePhoto, String UserType);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUser(String FirstName, String LastName, String UserName, String Password, String Email, String ProfilePhoto, String UserType)
        {
            User newUser = new User
            {
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = UserName,
                    Password = Password,
                    Email = Email,
                    ProfilePhoto = ProfilePhoto,
                    UserType = UserType
            };
            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> DeleteUser(int id)
        {
            User  user = await _db.Users.FirstOrDefaultAsync(U => U.UserId == id);
            if (user != null) { _db.Users.Remove(user); }

            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return user;
        }
        public async Task<List<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _db.Users.Where(U => U.UserId == id).FirstAsync();
        }
        public async Task<User> UpdateUser(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
