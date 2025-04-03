using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCareDAO
{
    public class AssessmentQuestionDAO
    {
        private SkinCareDBContext _dbContext;
        private static AssessmentQuestionDAO instance;

        public AssessmentQuestionDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static AssessmentQuestionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssessmentQuestionDAO();
                }
                return instance;
            }
        }


        public AssessmentQuestion GetOne(string id)
        {
            LogHelper.LogInfo($"AssessmentQuestionDAO.GetOne - Retrieving assessment question with ID: {id}");

            var result = _dbContext.AssessmentQuestions
                .SingleOrDefault(a => a.Id.Equals(id));

            LogHelper.LogInfo($"AssessmentQuestionDAO.GetOne - Question found: {(result != null ? "Yes" : "No")}");

            return result;
        }

        public List<AssessmentQuestion> GetAllQuestions()
        {
            LogHelper.LogInfo("AssessmentQuestionDAO.GetAllQuestions - Retrieving all assessment questions");

            var result = _dbContext.AssessmentQuestions.ToList();

            LogHelper.LogInfo($"AssessmentQuestionDAO.GetAllQuestions - Retrieved {result.Count} questions");

            return result;
        }

        public void Add(AssessmentQuestion a)
        {
            LogHelper.LogInfo("AssessmentQuestionDAO.Add - Adding new assessment question");

            AssessmentQuestion cur = GetOne(a.Id);
            if (cur != null)
            {
                LogHelper.LogWarning($"AssessmentQuestionDAO.Add - Question with ID {a.Id} already exists");
                throw new Exception();
            }
            _dbContext.AssessmentQuestions.Add(a);
            _dbContext.SaveChanges();

            LogHelper.LogInfo($"AssessmentQuestionDAO.Add - Successfully added question with ID: {a.Id}");
        }

        public void Update(AssessmentQuestion a)
        {
            LogHelper.LogInfo($"AssessmentQuestionDAO.Update - Updating assessment question with ID: {a.Id}");

            AssessmentQuestion cur = GetOne(a.Id);
            if (cur == null)
            {
                LogHelper.LogWarning($"AssessmentQuestionDAO.Update - Question with ID {a.Id} not found");
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();

            LogHelper.LogInfo($"AssessmentQuestionDAO.Update - Successfully updated question with ID: {a.Id}");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"AssessmentQuestionDAO.Delete - Deleting assessment question with ID: {id}");

            AssessmentQuestion cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.AssessmentQuestions.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
                LogHelper.LogInfo($"AssessmentQuestionDAO.Delete - Successfully deleted question with ID: {id}");
            }
            else
            {
                LogHelper.LogWarning($"AssessmentQuestionDAO.Delete - Question with ID {id} not found");
            }
        }
    }
}