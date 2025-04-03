using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;
using SkinCareDAO.Utils;

namespace SkinCareRepository
{
    public class StaffRepository : IStaffRepository
    {
        public Staff GetOne(string id)
        {
            LogHelper.LogInfo($"StaffRepository.GetOne - Retrieving staff with ID: {id}");
            var result = StaffDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"StaffRepository.GetOne - Retrieved staff: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public List<Staff> GetAll()
        {
            LogHelper.LogInfo("StaffRepository.GetAll - Retrieving all staff");
            var result = StaffDAO.Instance.GetAll();
            LogHelper.LogInfo($"StaffRepository.GetAll - Retrieved {result.Count} staff members");
            return result;
        }

        public void Add(Staff a)
        {
            LogHelper.LogInfo($"StaffRepository.Add - Adding new staff member: {a.FirstName} {a.LastName}");
            StaffDAO.Instance.Add(a);
            LogHelper.LogInfo($"StaffRepository.Add - Successfully added staff with ID: {a.Id}");
        }

        public void Update(Staff a)
        {
            LogHelper.LogInfo($"StaffRepository.Update - Updating staff with ID: {a.Id}");
            StaffDAO.Instance.Update(a);
            LogHelper.LogInfo($"StaffRepository.Update - Successfully updated staff");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"StaffRepository.Delete - Deleting staff with ID: {id}");
            StaffDAO.Instance.Delete(id);
            LogHelper.LogInfo($"StaffRepository.Delete - Staff deletion processed");
        }
    }
}