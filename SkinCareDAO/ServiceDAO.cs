using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class ServiceDAO
    {

        private SkinCareDBContext _dbContext;
        private static ServiceDAO instance;

        public ServiceDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static ServiceDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceDAO();
                }
                return instance;
            }
        }

        public Service GetOne(string id)
        {
            return _dbContext.Services
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<Service> GetAll()
        {
            return _dbContext.Services
                .ToList();
        }

        public void Add(Service a)
        {
            Service cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            _dbContext.Services.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(Service a)
        {
            Service cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Service cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.Services.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }


    }
}
