using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

namespace SkinCareDAO
{
    public class AssessmentOptionsDAO
    {
        private SkinCareDBContext _dbContext;
        private static AssessmentOptionsDAO instance;

        public AssessmentOptionsDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static AssessmentOptionsDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssessmentOptionsDAO();
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
                LogHelper.LogInfo($"AssessmentOptionsDAO.GetOptionsByQuestionId - Retrieving options for question ID: {questionId}");

                var options = _dbContext.AssessmentOptions
                    .Where(o => o.QuestionId == questionId)
                    .OrderBy(o => o.DisplayOrder)
                    .ToList();

                LogHelper.LogInfo($"AssessmentOptionsDAO.GetOptionsByQuestionId - Retrieved {options.Count} options for question ID: {questionId}");

                return options;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error retrieving assessment options for question ID: {questionId}", ex);
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
                LogHelper.LogInfo($"AssessmentOptionsDAO.GetOptionById - Retrieving option with ID: {optionId}");

                var option = _dbContext.AssessmentOptions
                    .FirstOrDefault(o => o.Id == optionId);

                LogHelper.LogInfo($"AssessmentOptionsDAO.GetOptionById - Option found: {(option != null ? "Yes" : "No")}");

                return option;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error retrieving assessment option with ID: {optionId}", ex);
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
                LogHelper.LogInfo($"AssessmentOptionsDAO.AddOption - Adding new option for question ID: {option.QuestionId}");

                _dbContext.AssessmentOptions.Add(option);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"AssessmentOptionsDAO.AddOption - Successfully added option with ID: {option.Id}");

                return option;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error adding assessment option: {option.OptionText}", ex);
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
                LogHelper.LogInfo($"AssessmentOptionsDAO.UpdateOption - Updating option with ID: {option.Id}");

                var existingOption = _dbContext.AssessmentOptions.FirstOrDefault(o => o.Id == option.Id);
                if (existingOption != null)
                {
                    _dbContext.Entry(existingOption).CurrentValues.SetValues(option);
                    _dbContext.SaveChanges();
                    LogHelper.LogInfo($"AssessmentOptionsDAO.UpdateOption - Successfully updated option with ID: {option.Id}");
                }
                else
                {
                    LogHelper.LogWarning($"AssessmentOptionsDAO.UpdateOption - Option with ID {option.Id} not found");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error updating assessment option with ID: {option.Id}", ex);
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
                LogHelper.LogInfo($"AssessmentOptionsDAO.DeleteOption - Deleting option with ID: {optionId}");

                var option = _dbContext.AssessmentOptions.FirstOrDefault(o => o.Id == optionId);
                if (option != null)
                {
                    _dbContext.AssessmentOptions.Remove(option);
                    _dbContext.SaveChanges();
                    LogHelper.LogInfo($"AssessmentOptionsDAO.DeleteOption - Successfully deleted option with ID: {optionId}");
                }
                else
                {
                    LogHelper.LogWarning($"AssessmentOptionsDAO.DeleteOption - Option with ID {optionId} not found");
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"Error deleting assessment option with ID: {optionId}", ex);
                Console.WriteLine($"Error deleting assessment option: {ex.Message}");
            }
        }
    }
}