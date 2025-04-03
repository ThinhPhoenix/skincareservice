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
    public class SkinAssesmentRepository : ISkinAssesmentRepository
    {

        public SkinAssessment GetById(string id) => SkinAssesmentDAO.Instance.GetById(id);
        public SkinAssessment GetOne(string id) => SkinAssesmentDAO.Instance.GetOne(id);    

        public List<SkinAssessment> GetAll() => SkinAssesmentDAO.Instance.GetAll();

        public void Add(SkinAssessment a) => SkinAssesmentDAO.Instance.Add(a);

        public void Update(SkinAssessment a) => SkinAssesmentDAO.Instance.Update(a);

        public void Delete(string id) => SkinAssesmentDAO.Instance.Delete(id);

    }
}
