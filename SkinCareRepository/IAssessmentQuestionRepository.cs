using Microsoft.EntityFrameworkCore;
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
        public List<AssessmentQuestion> GetAssessmentQuestions();
        public AssessmentQuestion GetOne(string id);

        public void Add(AssessmentQuestion a);

        public void Update(AssessmentQuestion a);

        public void Delete(string id);



    }
}
