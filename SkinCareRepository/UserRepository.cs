using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;
using SkinCareDAO.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkinCareRepository
{
    public class UserRepository : IUserRepository
    {
        public User? SignIn(string email, string password)
        {
            LogHelper.LogInfo($"UserRepository.SignIn - Attempting sign in for email: {email}");
            var result = UserDAO.Instance.SignIn(email, password);
            LogHelper.LogInfo($"UserRepository.SignIn - Sign in result: {(result != null ? "Success" : "Failed")}");
            return result;
        }

        public bool SignUp(User u, Customer c)
        {
            LogHelper.LogInfo($"UserRepository.SignUp - Registering new user with email: {u.Email}");
            try
            {
                UserDAO.Instance.Add(u);
                LogHelper.LogInfo($"UserRepository.SignUp - Successfully added user with ID: {u.Id}");

                c.UserId = u.Id;
                CustomerDAO.Instance.Add(c);
                LogHelper.LogInfo($"UserRepository.SignUp - Successfully added customer with ID: {c.Id}");

                LogHelper.LogInfo($"UserRepository.SignUp - Registration completed successfully");
                return true;
            }
            catch (Exception e)
            {
                LogHelper.LogError($"UserRepository.SignUp - Registration failed", e);
                return false;
            }
        }

        public bool SignUpStaff(Staff s)
        {
            LogHelper.LogInfo($"UserRepository.SignUpStaff - Registering new staff member");
            try
            {
                StaffDAO.Instance.Add(s);
                LogHelper.LogInfo($"UserRepository.SignUpStaff - Successfully added staff with ID: {s.Id}");
                return true;
            }
            catch (Exception e)
            {
                LogHelper.LogError($"UserRepository.SignUpStaff - Staff registration failed", e);
                return false;
            }
        }

        public User? GetUserByEmail(string email)
        {
            LogHelper.LogInfo($"UserRepository.GetUserByEmail - Retrieving user by email: {email}");
            var result = UserDAO.Instance.GetUserByEmail(email);
            LogHelper.LogInfo($"UserRepository.GetUserByEmail - User found: {(result != null ? "Yes" : "No")}");
            return result;
        }

        public User? GetOne(string id)
        {
            LogHelper.LogInfo($"UserRepository.GetOne - Retrieving user with ID: {id}");
            var result = UserDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"UserRepository.GetOne - Retrieved user: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public List<User> GetAll()
        {
            LogHelper.LogInfo("UserRepository.GetAll - Retrieving all users");
            var result = UserDAO.Instance.GetAll();
            LogHelper.LogInfo($"UserRepository.GetAll - Retrieved {result.Count} users");
            return result;
        }

        public void Add(User a)
        {
            LogHelper.LogInfo($"UserRepository.Add - Adding new user with email: {a.Email}");
            UserDAO.Instance.Add(a);
            LogHelper.LogInfo($"UserRepository.Add - Successfully added user with ID: {a.Id}");
        }

        public void Update(User a)
        {
            LogHelper.LogInfo($"UserRepository.Update - Updating user with ID: {a.Id}");
            UserDAO.Instance.Update(a);
            LogHelper.LogInfo($"UserRepository.Update - Successfully updated user");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"UserRepository.Delete - Deleting user with ID: {id}");
            UserDAO.Instance.Delete(id);
            LogHelper.LogInfo($"UserRepository.Delete - User deletion processed");
        }
    }
}