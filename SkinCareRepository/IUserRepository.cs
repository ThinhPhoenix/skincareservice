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
    public interface IUserRepository
    {
        public User? SignIn(string email, string password);

        public User? GetOne(string id);

        public bool SignUp(User u, Customer c);

        public List<User> GetAll();

        public User? GetUserByEmail(string email);


        public void Add(User a);

        public void Update(User a);

        public void Delete(string id);
    }
}
