using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
