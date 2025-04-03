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
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetOne(string id)
        {
            LogHelper.LogInfo($"CustomerRepository.GetOne - Retrieving customer with ID: {id}");
            var result = CustomerDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"CustomerRepository.GetOne - Retrieved customer: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public List<Customer> GetAll()
        {
            LogHelper.LogInfo("CustomerRepository.GetAll - Retrieving all customers");
            var result = CustomerDAO.Instance.GetAll();
            LogHelper.LogInfo($"CustomerRepository.GetAll - Retrieved {result.Count} customers");
            return result;
        }

        public Customer GetCustomerByUserId(string userId)
        {
            LogHelper.LogInfo($"CustomerRepository.GetCustomerByUserId - Retrieving customer by user ID: {userId}");
            var result = CustomerDAO.Instance.GetCustomerByUserId(userId);
            LogHelper.LogInfo($"CustomerRepository.GetCustomerByUserId - Retrieved customer: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public void Add(Customer a)
        {
            LogHelper.LogInfo($"CustomerRepository.Add - Adding new customer: {a.FirstName} {a.LastName}");
            CustomerDAO.Instance.Add(a);
            LogHelper.LogInfo($"CustomerRepository.Add - Successfully added customer with ID: {a.Id}");
        }

        public void Update(Customer a)
        {
            LogHelper.LogInfo($"CustomerRepository.Update - Updating customer with ID: {a.Id}");
            CustomerDAO.Instance.Update(a);
            LogHelper.LogInfo($"CustomerRepository.Update - Successfully updated customer");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"CustomerRepository.Delete - Deleting customer with ID: {id}");
            CustomerDAO.Instance.Delete(id);
            LogHelper.LogInfo($"CustomerRepository.Delete - Customer deletion processed");
        }

        public int[] GetDashBoardCustomer(int year)
        {
            LogHelper.LogInfo($"CustomerRepository.GetDashBoardCustomer - Getting dashboard data for year: {year}");
            var result = CustomerDAO.Instance.GetDashBoardCustomer(year);
            LogHelper.LogInfo($"CustomerRepository.GetDashBoardCustomer - Successfully retrieved dashboard data");
            return result;
        }
    }
}