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
    public class AssesmentOptionsRepository : IAssesmentOptionsRepository
    {
        public List<AssessmentOption> GetOptionsByQuestionId(string questionId)
        {
            LogHelper.LogInfo($"AssesmentOptionsRepository.GetOptionsByQuestionId - Retrieving options for question ID: {questionId}");
            var result = AssessmentOptionsDAO.Instance.GetOptionsByQuestionId(questionId);
            LogHelper.LogInfo($"AssesmentOptionsRepository.GetOptionsByQuestionId - Retrieved {result.Count} options");
            return result;
        }

        public AssessmentOption GetOptionById(string optionId)
        {
            LogHelper.LogInfo($"AssesmentOptionsRepository.GetOptionById - Retrieving option with ID: {optionId}");
            var result = AssessmentOptionsDAO.Instance.GetOptionById(optionId);
            LogHelper.LogInfo($"AssesmentOptionsRepository.GetOptionById - Retrieved option: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        /// <summary>
        /// Add a new assessment option
        /// </summary>
        /// <param name="option">The option to add</param>
        /// <returns>The added option with updated information</returns>
        public AssessmentOption AddOption(AssessmentOption option)
        {
            LogHelper.LogInfo($"AssesmentOptionsRepository.AddOption - Adding option for question ID: {option.QuestionId}");
            var result = AssessmentOptionsDAO.Instance.AddOption(option);
            LogHelper.LogInfo($"AssesmentOptionsRepository.AddOption - Option added: {(result != null ? "Success" : "Failed")}");
            return result;
        }

        /// <summary>
        /// Update an existing assessment option
        /// </summary>
        /// <param name="option">The option with updated information</param>
        /// <returns>True if update was successful, false otherwise</returns>
        public void UpdateOption(AssessmentOption option)
        {
            LogHelper.LogInfo($"AssesmentOptionsRepository.UpdateOption - Updating option with ID: {option.Id}");
            AssessmentOptionsDAO.Instance.UpdateOption(option);
            LogHelper.LogInfo("AssesmentOptionsRepository.UpdateOption - Option update processed");
        }

        /// <summary>
        /// Delete an assessment option
        /// </summary>
        /// <param name="optionId">The ID of the option to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public void DeleteOption(string optionId)
        {
            LogHelper.LogInfo($"AssesmentOptionsRepository.DeleteOption - Deleting option with ID: {optionId}");
            AssessmentOptionsDAO.Instance.DeleteOption(optionId);
            LogHelper.LogInfo("AssesmentOptionsRepository.DeleteOption - Option deletion processed");
        }
    }
}