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
    public class SkinAssesmentRepository : ISkinAssesmentRepository
    {
        public SkinAssessment GetOne(string id)
        {
            LogHelper.LogInfo($"SkinAssesmentRepository.GetOne - Retrieving skin assessment with ID: {id}");
            var result = SkinAssesmentDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"SkinAssesmentRepository.GetOne - Retrieved assessment: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public SkinAssessment GetById(string id) => SkinAssesmentDAO.Instance.GetById(id);   
        public List<SkinAssessment> GetAll()
        {
            LogHelper.LogInfo("SkinAssesmentRepository.GetAll - Retrieving all skin assessments");
            var result = SkinAssesmentDAO.Instance.GetAll();
            LogHelper.LogInfo($"SkinAssesmentRepository.GetAll - Retrieved {result.Count} assessments");
            return result;
        }

        public void Add(SkinAssessment a)
        {
            LogHelper.LogInfo($"SkinAssesmentRepository.Add - Adding assessment for customer: {a.CustomerId}");
            SkinAssesmentDAO.Instance.Add(a);
            LogHelper.LogInfo($"SkinAssesmentRepository.Add - Successfully added assessment with ID: {a.Id}");
        }

        public void Update(SkinAssessment a)
        {
            LogHelper.LogInfo($"SkinAssesmentRepository.Update - Updating assessment with ID: {a.Id}");
            SkinAssesmentDAO.Instance.Update(a);
            LogHelper.LogInfo($"SkinAssesmentRepository.Update - Successfully updated assessment");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"SkinAssesmentRepository.Delete - Deleting assessment with ID: {id}");
            SkinAssesmentDAO.Instance.Delete(id);
            LogHelper.LogInfo($"SkinAssesmentRepository.Delete - Assessment deletion processed");
        }
    }
}