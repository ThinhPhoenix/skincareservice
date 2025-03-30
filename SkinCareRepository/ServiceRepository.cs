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
        public Task<List<Service>> GetAllAsync()
        {
            var result = ServiceDAO.Instance.GetAll();
            return Task.FromResult(result);
        }

        public Task<Service> GetOneAsync(string id)
        {
            var result = ServiceDAO.Instance.GetOne(id);
            return Task.FromResult(result);
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
