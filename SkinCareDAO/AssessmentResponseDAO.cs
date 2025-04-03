using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

namespace SkinCareDAO
{
    public class AssessmentResponseDAO
    {

        private SkinCareDBContext _dbContext;
        private static AssessmentResponseDAO instance;

        public AssessmentResponseDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static AssessmentResponseDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssessmentResponseDAO();
                }
                return instance;
            }
        }


        public AssessmentResponse GetOne(string id)
        {
            LogHelper.LogInfo($"AssessmentResponseDAO.GetOne - Retrieving assessment response with ID: {id}");

            var result = _dbContext.AssessmentResponses
                .SingleOrDefault(a => a.AssessmentId.Equals(id));

            LogHelper.LogInfo($"AssessmentResponseDAO.GetOne - Response found: {(result != null ? "Yes" : "No")}");

            return result;
        }

        public List<AssessmentResponse> GetAll()
        {
            LogHelper.LogInfo("AssessmentResponseDAO.GetAll - Retrieving all assessment responses");

            var result = _dbContext.AssessmentResponses.ToList();

            LogHelper.LogInfo($"AssessmentResponseDAO.GetAll - Retrieved {result.Count} responses");

            return result;
        }

        public void Add(AssessmentResponse a)
        {
            LogHelper.LogInfo("AssessmentResponseDAO.Add - Adding new assessment response");

            AssessmentResponse cur = GetOne(a.AssessmentId);
            if (cur != null)
            {
                LogHelper.LogWarning($"AssessmentResponseDAO.Add - Response with ID {a.AssessmentId} already exists");
                throw new Exception();
            }
            _dbContext.AssessmentResponses.Add(a);
            _dbContext.SaveChanges();

            LogHelper.LogInfo($"AssessmentResponseDAO.Add - Successfully added response for assessment ID: {a.AssessmentId}");
        }

        public void Update(AssessmentResponse a)
        {
            LogHelper.LogInfo($"AssessmentResponseDAO.Update - Updating assessment response with ID: {a.AssessmentId}");

            AssessmentResponse cur = GetOne(a.AssessmentId);
            if (cur == null)
            {
                LogHelper.LogWarning($"AssessmentResponseDAO.Update - Response with ID {a.AssessmentId} not found");
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();

            LogHelper.LogInfo($"AssessmentResponseDAO.Update - Successfully updated response with ID: {a.AssessmentId}");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"AssessmentResponseDAO.Delete - Deleting assessment response with ID: {id}");

            AssessmentResponse cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.AssessmentResponses.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
                LogHelper.LogInfo($"AssessmentResponseDAO.Delete - Successfully deleted response with ID: {id}");
            }
            else
            {
                LogHelper.LogWarning($"AssessmentResponseDAO.Delete - Response with ID {id} not found");
            }
        }

    }
}