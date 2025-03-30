using SkinCareBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinCareRepository
{
    public interface IAssessmentQuestionRepository
    {
        public List<AssessmentQuestion> GetPagedAssessmentQuestions(int pageNumber, int pageSize);
    }
}
