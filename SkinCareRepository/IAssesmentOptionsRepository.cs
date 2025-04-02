using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

namespace SkinCareRepository
{
    public interface IAssesmentOptionsRepository
    {
        public List<AssessmentOption> GetOptionsByQuestionId(string questionId);

        public AssessmentOption GetOptionById(string optionId);

        public AssessmentOption AddOption(AssessmentOption option);

        public void UpdateOption(AssessmentOption option);


        public void DeleteOption(string optionId);
    }
}
