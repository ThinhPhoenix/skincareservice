using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class SkinAssesmentDAO
    {

        private SkinCareDBContext _dbContext;
        private static SkinAssesmentDAO instance;

        public SkinAssesmentDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static SkinAssesmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SkinAssesmentDAO();
                }
                return instance;
            }
        }


        public SkinAssessment GetOne(string id)
        {
            return _dbContext.SkinAssessments
                .Include(a=>a.Customer)
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public SkinAssessment GetById(string id)
        {
            return _dbContext.SkinAssessments
                .Include(a => a.Customer)
                .ThenInclude(c => c.User)  // Include the User data
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<SkinAssessment> GetAll()
        {
            return _dbContext.SkinAssessments
                .Include(a => a.Customer)
                .ThenInclude(c => c.User)  // Include the User data
                .ToList();
        }

        public void Add(SkinAssessment a)
        {
            SkinAssessment cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            a.Id = Guid.NewGuid().ToString();
            _dbContext.SkinAssessments.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(SkinAssessment a)
        {
            SkinAssessment cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            SkinAssessment cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.SkinAssessments.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

    }
}
