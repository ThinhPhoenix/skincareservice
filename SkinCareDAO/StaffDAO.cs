using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class StaffDAO
    {

        private SkinCareDBContext _dbContext;
        private static StaffDAO instance;

        public StaffDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static StaffDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StaffDAO();
                }
                return instance;
            }
        }


        public Staff GetOne(string id)
        {
            return _dbContext.Staffs
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<Staff> GetAll()
        {
            return _dbContext.Staffs.ToList();
        }

        public void Add(Staff a)
        {
            

                _dbContext.Staffs.Add(a);
            
            
            _dbContext.SaveChanges();
        }

        public void Update(Staff a)
        {
            Staff cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Staff cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.Staffs.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }


    }
}
