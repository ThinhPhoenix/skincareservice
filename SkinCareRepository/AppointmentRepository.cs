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
    public class AppointmentRepository : IAppointmentRepository
    {
        public int[] GetDashBoardAppointment(int year)
        {
            return AppointmentDAO.Instance.GetDashBoardAppointment(year);
        }
    }
}
