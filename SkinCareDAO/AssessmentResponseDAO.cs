using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

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
            return _dbContext.AssessmentResponses
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<AssessmentResponse> GetAll()
        {
            return _dbContext.AssessmentResponses

                .ToList();
        }

        public void Add(AssessmentResponse a)
{
    try
    {
        using var context = new SkinCareDBContext();
        
        // Make sure we have all required fields
        if (string.IsNullOrEmpty(a.Id))
        {
            a.Id = Guid.NewGuid().ToString();
        }
        
        if (string.IsNullOrEmpty(a.AssessmentId) || 
            string.IsNullOrEmpty(a.QuestionId) || 
            string.IsNullOrEmpty(a.OptionId))
        {
            throw new Exception("Assessment response is missing required fields (AssessmentId, QuestionId, or OptionId)");
        }
        
        // Make sure ResponseText is not null
        a.ResponseText = a.ResponseText ?? string.Empty;
        
        // Verify that the referenced entities exist
        var assessmentExists = context.SkinAssessments.Any(s => s.Id == a.AssessmentId);
        var questionExists = context.AssessmentQuestions.Any(q => q.Id == a.QuestionId);
        var optionExists = context.AssessmentOptions.Any(o => o.Id == a.OptionId);
        
        if (!assessmentExists)
        {
            throw new Exception($"Assessment with ID {a.AssessmentId} does not exist");
        }
        
        if (!questionExists)
        {
            throw new Exception($"Question with ID {a.QuestionId} does not exist");
        }
        
        if (!optionExists)
        {
            throw new Exception($"Option with ID {a.OptionId} does not exist");
        }
        
        // Add the response
        context.AssessmentResponses.Add(a);
        context.SaveChanges();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error in AssessmentResponseDAO.Add: {ex.Message}");
        if (ex.InnerException != null)
        {
            Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
        }
        throw; // Rethrow with better context
    }
}

        public void Update(AssessmentResponse a)
        {
            AssessmentResponse cur = GetOne(a.AssessmentId);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            AssessmentResponse cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.AssessmentResponses.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

        public List<AssessmentResponse> GetResponsesByAssessmentId(string assessmentId)
        {
            return _dbContext.AssessmentResponses
                .Where(r => r.AssessmentId == assessmentId)
                .ToList();
        }
            
    }
}
