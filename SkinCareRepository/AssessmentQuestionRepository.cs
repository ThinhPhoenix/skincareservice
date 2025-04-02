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
        public List<AssessmentQuestion> GetAssessmentQuestions() => AssessmentQuestionDAO.Instance.GetAllQuestions();

        public AssessmentQuestion GetOne(string id) => AssessmentQuestionDAO.Instance.GetOne(id);

        public void Add(AssessmentQuestion a) => AssessmentQuestionDAO.Instance.Add(a);

        public void Update(AssessmentQuestion a) => AssessmentQuestionDAO.Instance.Update(a);

        public void Delete(string id) => AssessmentQuestionDAO.Instance.Delete(id);

    }
}
