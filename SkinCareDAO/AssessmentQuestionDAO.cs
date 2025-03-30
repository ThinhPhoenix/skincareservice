using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
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

        public List<AssessmentQuestion> GetPagedAssessmentQuestions(int pageNumber, int pageSize)
        {
            var questions = _dbContext.AssessmentQuestions
                .Include(q => q.AssessmentOptions)
                .OrderBy(q => q.DisplayOrder)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return questions;
        }
    }
}
