using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

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
            LogHelper.LogInfo($"StaffDAO.GetOne - Retrieving staff with ID: {id}");

            var staff = _dbContext.Staffs
                .SingleOrDefault(a => a.Id.Equals(id));

            LogHelper.LogInfo($"StaffDAO.GetOne - Staff found: {(staff != null ? "Yes" : "No")}");

            return staff;
        }

        public List<Staff> GetAll()
        {
            LogHelper.LogInfo("StaffDAO.GetAll - Retrieving all staff");

            var staff = _dbContext.Staffs.ToList();

            LogHelper.LogInfo($"StaffDAO.GetAll - Retrieved {staff.Count} staff members");

            return staff;
        }

        public void Add(Staff a)
        {
            LogHelper.LogInfo($"StaffDAO.Add - Adding new staff member");

            _dbContext.Staffs.Add(a);
            _dbContext.SaveChanges();

            LogHelper.LogInfo($"StaffDAO.Add - Successfully added staff with ID: {a.Id}");
        }

        public void Update(Staff a)
        {
            LogHelper.LogInfo($"StaffDAO.Update - Updating staff with ID: {a.Id}");

            Staff cur = GetOne(a.Id);
            if (cur == null)
            {
                LogHelper.LogWarning($"StaffDAO.Update - Staff with ID {a.Id} not found");
                throw new Exception();
            }

            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();

            LogHelper.LogInfo($"StaffDAO.Update - Successfully updated staff with ID: {a.Id}");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"StaffDAO.Delete - Deleting staff with ID: {id}");

            Staff cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.Staffs.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
                LogHelper.LogInfo($"StaffDAO.Delete - Successfully deleted staff with ID: {id}");
            }
            else
            {
                LogHelper.LogWarning($"StaffDAO.Delete - Staff with ID {id} not found");
            }
        }
    }
}