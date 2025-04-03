using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;

namespace SkinCareRepository
{
    public class AssessmentResponseRepository : IAssessmentResponseRepository
    {
        public AssessmentResponse GetOne(string id) => AssessmentResponseDAO.Instance.GetOne(id);   

        public List<AssessmentResponse> GetAll() => AssessmentResponseDAO.Instance.GetAll();

        public void Add(AssessmentResponse a) => AssessmentResponseDAO.Instance.Add(a);

        public void Update(AssessmentResponse a) => AssessmentResponseDAO.Instance.Update(a);   

        public void Delete(string id) => AssessmentResponseDAO.Instance.Delete(id);
        public List<AssessmentResponse> GetResponsesByAssessmentId(string assessmentId) => AssessmentResponseDAO.Instance.GetResponsesByAssessmentId(assessmentId);
    }
}
