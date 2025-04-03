using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

namespace SkinCareDAO
{
    public class CustomerDAO
    {
        private SkinCareDBContext _dbContext;
        private static CustomerDAO instance;

        public CustomerDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerDAO();
                }
                return instance;
            }
        }

        public Customer GetOne(string id)
        {
            try
            {
                LogHelper.LogInfo($"Retrieving customer with ID: {id}");
                return _dbContext.Customers
                    .SingleOrDefault(a => a.Id.Equals(id));
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error retrieving customer with ID: {id}", ex);
                throw;
            }
        }

        public Customer GetCustomerByUserId(string userId)
        {
            try
            {
                LogHelper.LogInfo($"Retrieving customer by user ID: {userId}");
                return _dbContext.Customers.FirstOrDefault(c => c.UserId == userId);
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error retrieving customer by user ID: {userId}", ex);
                throw;
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                LogHelper.LogInfo("Retrieving all customers");
                return _dbContext.Customers
                    .ToList();
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Error retrieving all customers", ex);
                throw;
            }
        }

        public void Add(Customer a)
        {
            try
            {
                LogHelper.LogInfo("Adding new customer");

                Customer cur = GetOne(a.Id);
                if (cur != null)
                {
                    LogHelper.LogWarning($"Customer with ID {a.Id} already exists");
                    throw new Exception($"Customer with ID {a.Id} already exists");
                }

                a.Id = Guid.NewGuid().ToString();
                LogHelper.LogDebug($"Generated new customer ID: {a.Id}");

                _dbContext.Customers.Add(a);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"Successfully added customer with ID: {a.Id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Error adding customer", ex);
                throw;
            }
        }

        public void Update(Customer a)
        {
            try
            {
                LogHelper.LogInfo($"Updating customer with ID: {a.Id}");

                Customer cur = GetOne(a.Id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"Customer with ID {a.Id} not found for update");
                    throw new Exception($"Customer with ID {a.Id} not found");
                }

                _dbContext.Entry(cur).CurrentValues.SetValues(a);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"Successfully updated customer with ID: {a.Id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error updating customer with ID: {a.Id}", ex);
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                LogHelper.LogInfo($"Deleting customer with ID: {id}");

                Customer cur = GetOne(id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"Customer with ID {id} not found for deletion");
                    return;
                }

                _dbContext.Customers.Remove(cur);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"Successfully deleted customer with ID: {id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error deleting customer with ID: {id}", ex);
                throw;
            }
        }

        public int[] GetDashBoardCustomer(int year)
        {
            int[] monthlyCustomers = new int[12];

            try
            {
                LogHelper.LogInfo($"Retrieving customer dashboard data for year: {year}");

                var customersForYear = _dbContext.Customers
                    .Include(c => c.User)  // Explicitly include the User navigation property
                    .Where(c => c.User != null && c.User.CreatedAt.Year == year)
                    .ToList();

                foreach (var customer in customersForYear)
                {
                    // Month is 1-based, so subtract 1 for array index
                    int monthIndex = customer.User.CreatedAt.Month - 1;
                    monthlyCustomers[monthIndex]++;
                }

                LogHelper.LogInfo($"Successfully retrieved customer dashboard data for year: {year}");
                return monthlyCustomers;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error retrieving customer dashboard data for year: {year}", ex);
                throw;
            }
        }
    }
}