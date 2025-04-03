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
            try
            {
                LogHelper.LogInfo($"UserDAO.SignIn - Attempting sign in for email: {email}");

                var encryptedPassword = MyUtils.Encrypt(password);
                var user = _dbContext.Users.SingleOrDefault(
                    u => u.Email.ToLower().Equals(email.ToLower()) && u.Password.Equals(encryptedPassword)
                );

                LogHelper.LogInfo($"UserDAO.SignIn - Sign in result for {email}: {(user != null ? "Success" : "Failed")}");
                return user;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"UserDAO.SignIn - Error during sign in for email: {email}", ex);
                throw;
            }
        }

        public User? GetOne(string id)
        {
            try
            {
                LogHelper.LogInfo($"UserDAO.GetOne - Retrieving user with ID: {id}");

                var user = _dbContext.Users.SingleOrDefault(a => a.Id.Equals(id));

                LogHelper.LogInfo($"UserDAO.GetOne - User found: {(user != null ? "Yes" : "No")}");
                return user;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"UserDAO.GetOne - Error retrieving user with ID: {id}", ex);
                throw;
            }
        }

        public User? GetUserByEmail(string email)
        {
            try
            {
                LogHelper.LogInfo($"UserDAO.GetUserByEmail - Retrieving user with email: {email}");

                var user = _dbContext.Users.SingleOrDefault(a => a.Email.Equals(email));

                LogHelper.LogInfo($"UserDAO.GetUserByEmail - User found: {(user != null ? "Yes" : "No")}");
                return user;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"UserDAO.GetUserByEmail - Error retrieving user with email: {email}", ex);
                throw;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                LogHelper.LogInfo("UserDAO.GetAll - Retrieving all users");

                var users = _dbContext.Users.ToList();

                LogHelper.LogInfo($"UserDAO.GetAll - Retrieved {users.Count} users");
                return users;
            }
            catch (Exception ex)
            {
                LogHelper.LogError("UserDAO.GetAll - Error retrieving all users", ex);
                throw;
            }
        }

        public void Add(User a)
        {
            try
            {
                LogHelper.LogInfo("UserDAO.Add - Adding new user");

                if (a == null)
                {
                    LogHelper.LogError("UserDAO.Add - User cannot be null");
                    throw new ArgumentNullException(nameof(a), "User cannot be null.");
                }

                if (string.IsNullOrWhiteSpace(a.Password))
                {
                    LogHelper.LogError("UserDAO.Add - Password cannot be empty");
                    throw new ArgumentException("Password cannot be empty.", nameof(a.Password));
                }

                if (!string.IsNullOrWhiteSpace(a.Id))
                {
                    User cur = GetOne(a.Id);
                    if (cur != null)
                    {
                        LogHelper.LogWarning($"UserDAO.Add - User with ID {a.Id} already exists");
                        throw new InvalidOperationException($"User with ID {a.Id} already exists.");
                    }
                }

                a.Id = Guid.NewGuid().ToString();
                LogHelper.LogInfo($"UserDAO.Add - Generated new user ID: {a.Id}");

                string encryptedPassword = MyUtils.Encrypt(a.Password);
                if (encryptedPassword == null)
                {
                    LogHelper.LogError("UserDAO.Add - Password encryption failed");
                    throw new InvalidOperationException("Password encryption failed.");
                }
                a.Password = encryptedPassword;

                _dbContext.Users.Add(a);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"UserDAO.Add - Successfully added user with ID: {a.Id}");
            }
            catch (Exception ex) when (!(ex is ArgumentNullException || ex is ArgumentException || ex is InvalidOperationException))
            {
                LogHelper.LogError("UserDAO.Add - Error adding user", ex);
                throw;
            }
        }

        public void Update(User a)
        {
            try
            {
                LogHelper.LogInfo($"UserDAO.Update - Updating user with ID: {a.Id}");

                User cur = GetOne(a.Id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"UserDAO.Update - User with ID {a.Id} not found");
                    throw new Exception($"User with ID {a.Id} not found");
                }

                _dbContext.Entry(cur).CurrentValues.SetValues(a);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"UserDAO.Update - Successfully updated user with ID: {a.Id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"UserDAO.Update - Error updating user with ID: {a.Id}", ex);
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                LogHelper.LogInfo($"UserDAO.Delete - Deleting user with ID: {id}");

                User cur = GetOne(id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"UserDAO.Delete - User with ID {id} not found");
                    return;
                }

                _dbContext.Users.Remove(cur);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"UserDAO.Delete - Successfully deleted user with ID: {id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"UserDAO.Delete - Error deleting user with ID: {id}", ex);
                throw;
            }
        }
    }
}