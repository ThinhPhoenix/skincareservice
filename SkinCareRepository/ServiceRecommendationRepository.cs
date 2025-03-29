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
    public class ServiceRecommendationRepository : IServiceRecommendationRepository
    {
        public ServiceRecommendation? GetOne(string id)
        {
            return ServiceRecommendationDAO.Instance.GetOne(id);
        }

        public List<ServiceRecommendation> GetAll()
        {
            return ServiceRecommendationDAO.Instance.GetAll();
        }

        public void Add(ServiceRecommendation a)
        {
            ServiceRecommendationDAO.Instance.Add(a);
        }

        public void Update(ServiceRecommendation a)
        {
            ServiceRecommendationDAO.Instance.Update(a);
        }

        public void Delete(string id)
        {
            ServiceRecommendationDAO.Instance.Delete(id);
        }
    }
}
