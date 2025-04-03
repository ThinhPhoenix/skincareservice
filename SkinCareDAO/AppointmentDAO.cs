using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

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
            return _dbContext.Appointments
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<Appointment> GetAll()
        {
            return _dbContext.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Therapist)
                .Include(a => a.Service)
                .ToList();
        }

        public void Add(Appointment a)
        {
            Appointment cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            _dbContext.Appointments.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(Appointment a)
        {
            Appointment cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Appointment cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.Appointments.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

        public int[] GetDashBoardAppointment(int year)
        {
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

            return monthlyAppointments;
        }

        public List<Appointment> GetAppointmentsByCustomerId(string customerId)
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                
                appointments = _dbContext.Appointments
                    .Where(a => a.CustomerId == customerId)
                    .OrderByDescending(a => a.AppointmentDateTime)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving appointments by customer ID: {ex.Message}", ex);
            }

            return appointments;
        }
    }
}
