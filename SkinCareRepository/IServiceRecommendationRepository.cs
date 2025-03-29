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
    public interface IServiceRecommendationRepository
    {
        public ServiceRecommendation? GetOne(string id);

        public List<ServiceRecommendation> GetAll();

        public void Add(ServiceRecommendation a);

        public void Update(ServiceRecommendation a);

        public void Delete(string id);
    }
}
