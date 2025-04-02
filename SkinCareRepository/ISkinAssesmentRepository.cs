using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

namespace SkinCareRepository
{
    public interface ISkinAssesmentRepository
    {

        public SkinAssessment GetOne(string id);

        public List<SkinAssessment> GetAll();

        public void Add(SkinAssessment a);

        public void Update(SkinAssessment a);

        public void Delete(string id);

    }
}
