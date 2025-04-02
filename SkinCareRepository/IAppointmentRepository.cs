using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;

namespace SkinCareRepository
{
    public interface IAppointmentRepository
    {
        public int[] GetDashBoardAppointment(int year);

        public Appointment GetOne(string id);

        public List<Appointment> GetAll();

        public void Add(Appointment a);
    }
}
