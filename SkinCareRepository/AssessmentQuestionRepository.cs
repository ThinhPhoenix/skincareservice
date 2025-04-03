using SkinCareBussinessObject;
using SkinCareDAO;
using SkinCareDAO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCareRepository
{
    public class AssessmentQuestionRepository : IAssessmentQuestionRepository
    {
        public List<AssessmentQuestion> GetAssessmentQuestions()
        {
            LogHelper.LogInfo("AssessmentQuestionRepository.GetAssessmentQuestions - Retrieving all assessment questions");
            var result = AssessmentQuestionDAO.Instance.GetAllQuestions();
            LogHelper.LogInfo($"AssessmentQuestionRepository.GetAssessmentQuestions - Retrieved {result.Count} questions");
            return result;
        }

        public AssessmentQuestion GetOne(string id)
        {
            LogHelper.LogInfo($"AssessmentQuestionRepository.GetOne - Retrieving question with ID: {id}");
            var result = AssessmentQuestionDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"AssessmentQuestionRepository.GetOne - Retrieved question: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public void Add(AssessmentQuestion a)
        {
            LogHelper.LogInfo($"AssessmentQuestionRepository.Add - Adding new question: {a.QuestionText}");
            AssessmentQuestionDAO.Instance.Add(a);
            LogHelper.LogInfo($"AssessmentQuestionRepository.Add - Successfully added question with ID: {a.Id}");
        }

        public void Update(AssessmentQuestion a)
        {
            LogHelper.LogInfo($"AssessmentQuestionRepository.Update - Updating question with ID: {a.Id}");
            AssessmentQuestionDAO.Instance.Update(a);
            LogHelper.LogInfo($"AssessmentQuestionRepository.Update - Successfully updated question");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"AssessmentQuestionRepository.Delete - Deleting question with ID: {id}");
            AssessmentQuestionDAO.Instance.Delete(id);
            LogHelper.LogInfo($"AssessmentQuestionRepository.Delete - Question deletion processed");
        }
    }
}