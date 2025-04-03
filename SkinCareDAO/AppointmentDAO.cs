using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

namespace SkinCareDAO
{
    public class AppointmentDAO
    {
        private SkinCareDBContext _dbContext;
        private static AppointmentDAO instance;

        public AppointmentDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static AppointmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentDAO();
                }
                return instance;
            }
        }

        public Appointment GetOne(string id)
        {
            try
            {
                LogHelper.LogInfo($"AppointmentDAO.GetOne - Retrieving appointment with ID: {id}");
                var appointment = _dbContext.Appointments
                    .SingleOrDefault(a => a.Id.Equals(id));

                LogHelper.LogInfo($"AppointmentDAO.GetOne - Appointment found: {(appointment != null ? "Yes" : "No")}");
                return appointment;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"AppointmentDAO.GetOne - Error retrieving appointment with ID: {id}", ex);
                throw;
            }
        }

        public List<Appointment> GetAll()
        {
            try
            {
                LogHelper.LogInfo("AppointmentDAO.GetAll - Retrieving all appointments with relationships");
                return _dbContext.Appointments
                    .Include(a => a.Customer)
                    .Include(a => a.Therapist)
                    .Include(a => a.Service)
                    .ToList();
            }
            catch (Exception ex)
            {
                LogHelper.LogError("AppointmentDAO.GetAll - Error retrieving all appointments", ex);
                throw;
            }
        }

        public void Add(Appointment a)
        {
            try
            {
                LogHelper.LogInfo($"AppointmentDAO.Add - Adding new appointment for customer: {a.CustomerId}, therapist: {a.TherapistId}, service: {a.ServiceId}");

                if (!string.IsNullOrEmpty(a.Id))
                {
                    Appointment cur = GetOne(a.Id);
                    if (cur != null)
                    {
                        LogHelper.LogWarning($"AppointmentDAO.Add - Appointment with ID {a.Id} already exists");
                        throw new Exception($"Appointment with ID {a.Id} already exists");
                    }
                }
                else
                {
                    a.Id = Guid.NewGuid().ToString();
                    LogHelper.LogInfo($"AppointmentDAO.Add - Generated new appointment ID: {a.Id}");
                }

                _dbContext.Appointments.Add(a);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"AppointmentDAO.Add - Successfully added appointment with ID: {a.Id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError("AppointmentDAO.Add - Error adding appointment", ex);
                throw;
            }
        }

        public void Update(Appointment a)
        {
            try
            {
                LogHelper.LogInfo($"AppointmentDAO.Update - Updating appointment with ID: {a.Id}");

                Appointment cur = GetOne(a.Id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"AppointmentDAO.Update - Appointment with ID {a.Id} not found");
                    throw new Exception($"Appointment with ID {a.Id} not found");
                }

                _dbContext.Entry(cur).CurrentValues.SetValues(a);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"AppointmentDAO.Update - Successfully updated appointment with ID: {a.Id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"AppointmentDAO.Update - Error updating appointment with ID: {a.Id}", ex);
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                LogHelper.LogInfo($"AppointmentDAO.Delete - Deleting appointment with ID: {id}");

                Appointment cur = GetOne(id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"AppointmentDAO.Delete - Appointment with ID {id} not found");
                    return;
                }

                _dbContext.Appointments.Remove(cur);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"AppointmentDAO.Delete - Successfully deleted appointment with ID: {id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"AppointmentDAO.Delete - Error deleting appointment with ID: {id}", ex);
                throw;
            }
        }

        public int[] GetDashBoardAppointment(int year)
        {
            try
            {
                LogHelper.LogInfo($"AppointmentDAO.GetDashBoardAppointment - Retrieving appointment data for year: {year}");

                int[] monthlyAppointments = new int[12];

                var appointmentsForYear = _dbContext.Appointments
                    .Where(a => a.CreatedAt.Year == year)
                    .ToList();

                foreach (var appointment in appointmentsForYear)
                {
                    // Month is 1-based, so subtract 1 for array index
                    int monthIndex = appointment.CreatedAt.Month - 1;
                    monthlyAppointments[monthIndex]++;
                }

                LogHelper.LogInfo($"AppointmentDAO.GetDashBoardAppointment - Successfully retrieved appointment data for year: {year}");
                return monthlyAppointments;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"AppointmentDAO.GetDashBoardAppointment - Error retrieving appointment data for year: {year}", ex);
                throw;
            }
        }

        public List<Appointment> GetAppointmentsByCustomerId(string customerId)
        {
            try
            {
                LogHelper.LogInfo($"AppointmentDAO.GetAppointmentsByCustomerId - Retrieving appointments for customer ID: {customerId}");

                var appointments = _dbContext.Appointments
                    .Where(a => a.CustomerId == customerId)
                    .OrderByDescending(a => a.AppointmentDateTime)
                    .ToList();

                LogHelper.LogInfo($"AppointmentDAO.GetAppointmentsByCustomerId - Found {appointments.Count} appointments for customer ID: {customerId}");
                return appointments;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"AppointmentDAO.GetAppointmentsByCustomerId - Error retrieving appointments for customer ID: {customerId}", ex);
                throw new Exception($"Error retrieving appointments by customer ID: {ex.Message}", ex);
            }
        }
    }
}