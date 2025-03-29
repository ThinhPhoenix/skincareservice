using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class ServiceRecommendationDAO
    {

        private SkinCareDBContext _dbContext;
        private static ServiceRecommendationDAO instance;

        public ServiceRecommendationDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static ServiceRecommendationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceRecommendationDAO();
                }
                return instance;
            }
        }


        public ServiceRecommendation GetOne(string id)
        {
            return _dbContext.ServiceRecommendations
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<ServiceRecommendation> GetAll()
        {
            return _dbContext.ServiceRecommendations
                .ToList();
        }

        public void Add(ServiceRecommendation a)
        {
            ServiceRecommendation cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            a.Id = Guid.NewGuid().ToString();
            _dbContext.ServiceRecommendations.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(ServiceRecommendation a)
        {
            ServiceRecommendation cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            ServiceRecommendation cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.ServiceRecommendations.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

    }
}
