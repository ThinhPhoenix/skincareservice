using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

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
            return _dbContext.Customers
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public Customer GetCustomerByUserId(string userId)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.UserId == userId);
        }

        public List<Customer> GetAll()
        {
            return _dbContext.Customers
                .ToList();
        }

        public void Add(Customer a)
        {
            Customer cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            a.Id = Guid.NewGuid().ToString();
            _dbContext.Customers.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(Customer a)
        {
            Customer cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Customer cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.Customers.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

        public int[] GetDashBoardCustomer(int year)
        {
            int[] monthlyCustomers = new int[12];

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

            return monthlyCustomers;
        }
    }
}
