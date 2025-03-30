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
    public class StaffRepository : IStaffRepository
    {
        public Staff GetOne(string id)
            => StaffDAO.Instance.GetOne(id);

        public List<Staff> GetAll()
            => StaffDAO.Instance.GetAll();

        public void Add(Staff a)
            => StaffDAO.Instance.Add(a);

        public void Update(Staff a)
            => StaffDAO.Instance.Update(a);

        public void Delete(string id)
            => StaffDAO.Instance.Delete(id);
    }
}
