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
    public class ServiceRepository : IServiceRepository
    {
        public Service? GetOne(string id)
        {
            return ServiceDAO.Instance.GetOne(id);
        }

        public List<Service> GetAll()
        {
            return ServiceDAO.Instance.GetAll();
        }

        public void Add(Service a)
        {
            ServiceDAO.Instance.Add(a);
        }

        public void Update(Service a)
        {
            ServiceDAO.Instance.Update(a);
        }

        public void Delete(string id)
        {
            ServiceDAO.Instance.Delete(id);
        }
    }
}
