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
    public interface ICustomerRepository
    {
        public Customer GetOne(string id);

        public List<Customer> GetAll();

        public void Add(Customer a);

        public void Update(Customer a);

        public void Delete(string id);
        public int[] GetDashBoardCustomer(int year);

        public Customer GetCustomerByUserId(string userId);
    }
}
