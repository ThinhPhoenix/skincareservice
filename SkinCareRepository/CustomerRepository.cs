using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;

namespace SkinCareRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetOne(string id)
        {
            return CustomerDAO.Instance.GetOne(id);
        }

        public List<Customer> GetAll()
        {
            return CustomerDAO.Instance.GetAll();
        }

        public void Add(Customer a)
        {
            CustomerDAO.Instance.Add(a);
        }

        public void Update(Customer a)
        {
            CustomerDAO.Instance.Update(a);
        }

        public void Delete(string id)
        {
            CustomerDAO.Instance.Delete(id);
        }
    }
}
