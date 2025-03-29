using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

namespace SkinCareRepository
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {
        public ServiceCategory GetOne(string id)
        {
            return ServiceCategoryDAO.Instance.GetOne(id);
        }

        public List<ServiceCategory> GetAll()
        {
            return ServiceCategoryDAO.Instance.GetAll();
        }

        public void Add(ServiceCategory a)
        {
            ServiceCategoryDAO.Instance.Add(a);
        }

        public void Update(ServiceCategory a)
        {
            ServiceCategoryDAO.Instance.Update(a);
        }

        public void Delete(string id)
        {
            ServiceCategoryDAO.Instance.Delete(id);
        }
    }
}
