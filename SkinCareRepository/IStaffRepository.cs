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
    public interface IStaffRepository
    {
        public Staff GetOne(string id);

        public List<Staff> GetAll();

        public void Add(Staff a);

        public void Update(Staff a);

        public void Delete(string id);
    }
}
