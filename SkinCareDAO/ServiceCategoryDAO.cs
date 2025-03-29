using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO;

namespace SkinCareRepository
{
    public class ServiceCategoryDAO
    {

        private SkinCareDBContext _dbContext;
        private static ServiceCategoryDAO instance;

        public ServiceCategoryDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static ServiceCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceCategoryDAO();
                }
                return instance;
            }
        }


        public ServiceCategory GetOne(string id)
        {
            return _dbContext.ServiceCategories
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<ServiceCategory> GetAll()
        {
            return _dbContext.ServiceCategories
                .ToList();
        }

        public void Add(ServiceCategory a)
        {
            ServiceCategory cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            a.Id = Guid.NewGuid().ToString();
            _dbContext.ServiceCategories.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(ServiceCategory a)
        {
            ServiceCategory cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            ServiceCategory cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.ServiceCategories.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }


    }
}
