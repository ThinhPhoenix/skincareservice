using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class AssessmentResponseDAO
    {
            
        private SkinCareDBContext _dbContext;
        private static AssessmentResponseDAO instance;

        public AssessmentResponseDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static AssessmentResponseDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssessmentResponseDAO();
                }
                return instance;
            }
        }


        public AssessmentResponse GetOne(string id)
        {
            return _dbContext.AssessmentResponses
                .SingleOrDefault(a => a.AssessmentId.Equals(id));
        }

        public List<AssessmentResponse> GetAll()
        {
            return _dbContext.AssessmentResponses

                .ToList();
        }

        public void Add(AssessmentResponse a)
        {
            AssessmentResponse cur = GetOne(a.AssessmentId);
            if (cur != null)
            {
                throw new Exception();
            }
            _dbContext.AssessmentResponses.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(AssessmentResponse a)
        {
            AssessmentResponse cur = GetOne(a.AssessmentId);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            AssessmentResponse cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.AssessmentResponses.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

        public List<AssessmentResponse> GetResponsesByAssessmentId(string assessmentId)
        {
            return _dbContext.AssessmentResponses
                .Where(r => r.AssessmentId == assessmentId)
                .ToList();
        }
            
    }
}
