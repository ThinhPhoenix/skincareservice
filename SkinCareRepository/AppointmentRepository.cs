using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;
using SkinCareDAO.Utils;

namespace SkinCareRepository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public int[] GetDashBoardAppointment(int year)
        {
            LogHelper.LogInfo($"AppointmentRepository.GetDashBoardAppointment - Getting dashboard data for year: {year}");
            var result = AppointmentDAO.Instance.GetDashBoardAppointment(year);
            LogHelper.LogInfo($"AppointmentRepository.GetDashBoardAppointment - Successfully retrieved dashboard data");
            return result;
        }

        public Appointment GetOne(string id)
        {
            LogHelper.LogInfo($"AppointmentRepository.GetOne - Retrieving appointment with ID: {id}");
            var result = AppointmentDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"AppointmentRepository.GetOne - Retrieved appointment: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public List<Appointment> GetAll()
        {
            LogHelper.LogInfo("AppointmentRepository.GetAll - Retrieving all appointments");
            var result = AppointmentDAO.Instance.GetAll();
            LogHelper.LogInfo($"AppointmentRepository.GetAll - Retrieved {result.Count} appointments");
            return result;
        }

        public void Add(Appointment a)
        {
            LogHelper.LogInfo($"AppointmentRepository.Add - Adding appointment for customer: {a.CustomerId}, service: {a.ServiceId}");
            AppointmentDAO.Instance.Add(a);
            LogHelper.LogInfo($"AppointmentRepository.Add - Successfully added appointment with ID: {a.Id}");
        }

        public void Update(Appointment a)
        {
            LogHelper.LogInfo($"AppointmentRepository.Update - Updating appointment with ID: {a.Id}");
            AppointmentDAO.Instance.Update(a);
            LogHelper.LogInfo($"AppointmentRepository.Update - Successfully updated appointment");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"AppointmentRepository.Delete - Deleting appointment with ID: {id}");
            AppointmentDAO.Instance.Delete(id);
            LogHelper.LogInfo($"AppointmentRepository.Delete - Appointment deletion processed");
        }

        public List<Appointment> GetAppointmentsByCustomerId(string customerId)
        {
            LogHelper.LogInfo($"AppointmentRepository.GetAppointmentsByCustomerId - Retrieving appointments for customer: {customerId}");
            var result = AppointmentDAO.Instance.GetAppointmentsByCustomerId(customerId);
            LogHelper.LogInfo($"AppointmentRepository.GetAppointmentsByCustomerId - Retrieved {result.Count} appointments");
            return result;
        }
    }
}