using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

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
                u.Password.Equals(password)
            );
        }
    }
}
