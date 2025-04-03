using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;

namespace SkinCareRepository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public int[] GetDashBoardAppointment(int year)
        {
            return AppointmentDAO.Instance.GetDashBoardAppointment(year);
        }

        public Appointment GetOne(string id) => AppointmentDAO.Instance.GetOne(id);

        public List<Appointment> GetAll() => AppointmentDAO.Instance.GetAll();

        public void Add(Appointment a) => AppointmentDAO.Instance.Add(a);

        public void Update(Appointment a)
        {
            AppointmentDAO.Instance.Update(a);
        }

        public void Delete(string id)
        {
            AppointmentDAO.Instance.Delete(id);
        }

        public List<Appointment> GetAppointmentsByCustomerId(string customerId) => AppointmentDAO.Instance.GetAppointmentsByCustomerId(customerId);

    }
}
