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
    public class AssessmentResponseRepository : IAssessmentResponseRepository
    {
        public AssessmentResponse GetOne(string id)
        {
            LogHelper.LogInfo($"AssessmentResponseRepository.GetOne - Retrieving response with ID: {id}");
            var result = AssessmentResponseDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"AssessmentResponseRepository.GetOne - Retrieved response: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public List<AssessmentResponse> GetAll()
        {
            LogHelper.LogInfo("AssessmentResponseRepository.GetAll - Retrieving all assessment responses");
            var result = AssessmentResponseDAO.Instance.GetAll();
            LogHelper.LogInfo($"AssessmentResponseRepository.GetAll - Retrieved {result.Count} responses");
            return result;
        }

        public void Add(AssessmentResponse a)
        {
            LogHelper.LogInfo($"AssessmentResponseRepository.Add - Adding response for assessment: {a.AssessmentId}");
            AssessmentResponseDAO.Instance.Add(a);
            LogHelper.LogInfo($"AssessmentResponseRepository.Add - Successfully added response");
        }

        public void Update(AssessmentResponse a)
        {
            LogHelper.LogInfo($"AssessmentResponseRepository.Update - Updating response for assessment: {a.AssessmentId}");
            AssessmentResponseDAO.Instance.Update(a);
            LogHelper.LogInfo($"AssessmentResponseRepository.Update - Successfully updated response");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"AssessmentResponseRepository.Delete - Deleting response with ID: {id}");
            AssessmentResponseDAO.Instance.Delete(id);
            LogHelper.LogInfo($"AssessmentResponseRepository.Delete - Response deletion processed");
        }
    }
}