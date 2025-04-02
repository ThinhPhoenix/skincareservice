using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO;

namespace SkinCareRepository
{
    public interface IAssessmentResponseRepository
    {
        public AssessmentResponse GetOne(string id);

        public List<AssessmentResponse> GetAll();

        public void Add(AssessmentResponse a);

        public void Update(AssessmentResponse a);

        public void Delete(string id);
    }
}
