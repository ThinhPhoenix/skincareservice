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
    public class AssesmentOptionsRepository : IAssesmentOptionsRepository
    {
        public List<AssessmentOption> GetOptionsByQuestionId(string questionId) => AssessmentOptionsDAO.Instance.GetOptionsByQuestionId(questionId); 

        public AssessmentOption GetOptionById(string optionId) => AssessmentOptionsDAO.Instance.GetOptionById(optionId);

        /// <summary>
        /// Add a new assessment option
        /// </summary>
        /// <param name="option">The option to add</param>
        /// <returns>The added option with updated information</returns>
        public AssessmentOption AddOption(AssessmentOption option) => AssessmentOptionsDAO.Instance.AddOption(option);

        /// <summary>
        /// Update an existing assessment option
        /// </summary>
        /// <param name="option">The option with updated information</param>
        /// <returns>True if update was successful, false otherwise</returns>
        public void UpdateOption(AssessmentOption option) => AssessmentOptionsDAO.Instance.UpdateOption(option);

        /// <summary>
        /// Delete an assessment option
        /// </summary>
        /// <param name="optionId">The ID of the option to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public void DeleteOption(string optionId) => AssessmentOptionsDAO.Instance.DeleteOption(optionId);
    }
}
