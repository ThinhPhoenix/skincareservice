using SkinCareBussinessObject;
using SkinCareDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCareRepository
{
    public class AssessmentQuestionRepository : IAssessmentQuestionRepository
    {
        public List<AssessmentQuestion> GetPagedAssessmentQuestions(int pageNumber, int pageSize)
        {
            return AssessmentQuestionDAO.Instance.GetPagedAssessmentQuestions(pageNumber, pageSize);
        }
    }
}
