using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;
using SkinCareDAO.Utils;

namespace SkinCareRepository
{
    public class UserRepository : IUserRepository
    {
        public User? SignIn(string email, string password)
        {
            return UserDAO.Instance.SignIn(email, password);
        }


        public User? GetOne(string id)
        {
            return UserDAO.Instance.GetOne(id);
        }

        public List<User> GetAll()
        {
            return UserDAO.Instance.GetAll();
        }

        public void Add(User a)
        {
            UserDAO.Instance.Add(a);
        }

        public void Update(User a)
        {
            UserDAO.Instance.Update(a);
        }

        public void Delete(string id)
        {
            UserDAO.Instance.Delete(id);
        }
    }
}
