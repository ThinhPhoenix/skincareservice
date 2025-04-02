using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class AssesmentOptionsDAO
    {
        private SkinCareDBContext _dbContext;
        private static AssesmentOptionsDAO instance;

        public AssesmentOptionsDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static AssesmentOptionsDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssesmentOptionsDAO();
                }
                return instance;
            }
        }

        /// <summary>
        /// Get all assessment options for a specific question
        /// </summary>
        /// <param name="questionId">The ID of the question to get options for</param>
        /// <returns>A list of AssessmentOption objects</returns>
        public List<AssessmentOption> GetOptionsByQuestionId(string questionId)
        {
            try
            {
                return _dbContext.AssessmentOptions
                    .Where(o => o.QuestionId == questionId)
                    .OrderBy(o => o.DisplayOrder)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving assessment options: {ex.Message}");
                return new List<AssessmentOption>();
            }
        }

        /// <summary>
        /// Get a specific assessment option by ID
        /// </summary>
        /// <param name="optionId">The ID of the option to retrieve</param>
        /// <returns>The AssessmentOption object if found, null otherwise</returns>
        public AssessmentOption GetOptionById(string optionId)
        {
            try
            {
                return _dbContext.AssessmentOptions
                    .FirstOrDefault(o => o.Id == optionId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving assessment option: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Add a new assessment option
        /// </summary>
        /// <param name="option">The option to add</param>
        /// <returns>The added option with updated information</returns>
        public AssessmentOption AddOption(AssessmentOption option)
        {
            try
            {
                _dbContext.AssessmentOptions.Add(option);
                _dbContext.SaveChanges();
                return option;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding assessment option: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Update an existing assessment option
        /// </summary>
        /// <param name="option">The option with updated information</param>
        /// <returns>True if update was successful, false otherwise</returns>
        public void UpdateOption(AssessmentOption option)
        {
            try
            {
                var existingOption = _dbContext.AssessmentOptions.FirstOrDefault(o => o.Id == option.Id);
                if (existingOption != null)
                {
                    _dbContext.Entry(existingOption).CurrentValues.SetValues(option);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating assessment option: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete an assessment option
        /// </summary>
        /// <param name="optionId">The ID of the option to delete</param>
        public void DeleteOption(string optionId)
        {
            try
            {
                var option = _dbContext.AssessmentOptions.FirstOrDefault(o => o.Id == optionId);
                if (option != null)
                {
                    _dbContext.AssessmentOptions.Remove(option);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting assessment option: {ex.Message}");
            }
        }
    }
}