using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

namespace SkinCareDAO
{
    public class SkinAssesmentDAO
    {
        private SkinCareDBContext _dbContext;
        private static SkinAssesmentDAO instance;

        public SkinAssesmentDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static SkinAssesmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SkinAssesmentDAO();
                }
                return instance;
            }
        }

        public SkinAssessment GetOne(string id)
        {
            LogHelper.LogInfo($"SkinAssesmentDAO.GetOne - Retrieving skin assessment with ID: {id}");

            var assessment = _dbContext.SkinAssessments
                .SingleOrDefault(a => a.Id.Equals(id));

            LogHelper.LogInfo($"SkinAssesmentDAO.GetOne - Assessment found: {(assessment != null ? "Yes" : "No")}");

            return assessment;
        }

        public List<SkinAssessment> GetAll()
        {
            LogHelper.LogInfo("SkinAssesmentDAO.GetAll - Retrieving all skin assessments");

            var assessments = _dbContext.SkinAssessments.ToList();

            LogHelper.LogInfo($"SkinAssesmentDAO.GetAll - Retrieved {assessments.Count} skin assessments");

            return assessments;
        }

        public void Add(SkinAssessment a)
        {
            LogHelper.LogInfo($"SkinAssesmentDAO.Add - Adding new skin assessment for customer: {a.CustomerId}");

            SkinAssessment cur = GetOne(a.Id);
            if (cur != null)
            {
                LogHelper.LogWarning($"SkinAssesmentDAO.Add - Assessment with ID {a.Id} already exists");
                throw new Exception();
            }

            a.Id = Guid.NewGuid().ToString();
            LogHelper.LogInfo($"SkinAssesmentDAO.Add - Generated new assessment ID: {a.Id}");

            _dbContext.SkinAssessments.Add(a);
            _dbContext.SaveChanges();

            LogHelper.LogInfo($"SkinAssesmentDAO.Add - Successfully added skin assessment with ID: {a.Id}");
        }

        public void Update(SkinAssessment a)
        {
            LogHelper.LogInfo($"SkinAssesmentDAO.Update - Updating skin assessment with ID: {a.Id}");

            SkinAssessment cur = GetOne(a.Id);
            if (cur == null)
            {
                LogHelper.LogWarning($"SkinAssesmentDAO.Update - Assessment with ID {a.Id} not found");
                throw new Exception();
            }

            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();

            LogHelper.LogInfo($"SkinAssesmentDAO.Update - Successfully updated skin assessment with ID: {a.Id}");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"SkinAssesmentDAO.Delete - Deleting skin assessment with ID: {id}");

            SkinAssessment cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.SkinAssessments.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
                LogHelper.LogInfo($"SkinAssesmentDAO.Delete - Successfully deleted skin assessment with ID: {id}");
            }
            else
            {
                LogHelper.LogWarning($"SkinAssesmentDAO.Delete - Assessment with ID {id} not found");
            }
        }
    }
}