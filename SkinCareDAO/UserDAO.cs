using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

namespace SkinCareDAO
{
    public class UserDAO
    {

        private SkinCareDBContext _dbContext;
        private static UserDAO instance;

        public UserDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public User? SignIn(string email, string password)
        {
            return _dbContext.Users.SingleOrDefault(
                u =>
                u.Email.ToLower().Equals(email.ToLower())
                &&
                u.Password.Equals(MyUtils.Decrypt(password))
            );
        }

        public User? GetOne(string id)
        {
            return _dbContext.Users
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<User> GetAll()
        {
            return _dbContext.Users
                .ToList();
        }

        public void SignUp(User a)
        {
            User cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            a.Password = MyUtils.Encrypt(a.Password);
            _dbContext.Users.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(User a)
        {
            User cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            User cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.Users.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

    }
}
