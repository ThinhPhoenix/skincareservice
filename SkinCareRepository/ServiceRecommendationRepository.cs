using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;
using SkinCareDAO.Utils;

namespace SkinCareRepository
{
    public class ServiceRecommendationRepository : IServiceRecommendationRepository
    {
        public ServiceRecommendation? GetOne(string id)
        {
            LogHelper.LogInfo($"ServiceRecommendationRepository.GetOne - Retrieving recommendation with ID: {id}");
            var result = ServiceRecommendationDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"ServiceRecommendationRepository.GetOne - Retrieved recommendation: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public List<ServiceRecommendation> GetAll()
        {
            LogHelper.LogInfo("ServiceRecommendationRepository.GetAll - Retrieving all service recommendations");
            var result = ServiceRecommendationDAO.Instance.GetAll();
            LogHelper.LogInfo($"ServiceRecommendationRepository.GetAll - Retrieved {result.Count} recommendations");
            return result;
        }

        public void Add(ServiceRecommendation a)
        {
            LogHelper.LogInfo($"ServiceRecommendationRepository.Add - Adding recommendation for assessment: {a.AssessmentId}, service: {a.ServiceId}");
            ServiceRecommendationDAO.Instance.Add(a);
            LogHelper.LogInfo($"ServiceRecommendationRepository.Add - Successfully added recommendation with ID: {a.Id}");
        }

        public void Update(ServiceRecommendation a)
        {
            LogHelper.LogInfo($"ServiceRecommendationRepository.Update - Updating recommendation with ID: {a.Id}");
            ServiceRecommendationDAO.Instance.Update(a);
            LogHelper.LogInfo($"ServiceRecommendationRepository.Update - Successfully updated recommendation");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"ServiceRecommendationRepository.Delete - Deleting recommendation with ID: {id}");
            ServiceRecommendationDAO.Instance.Delete(id);
            LogHelper.LogInfo($"ServiceRecommendationRepository.Delete - Recommendation deletion processed");
        }
    }
}