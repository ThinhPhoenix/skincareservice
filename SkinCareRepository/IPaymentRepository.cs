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
    public interface IPaymentRepository
    {
        public decimal[] GetDashBoardRevenue(int year);

        public Payment GetOne(string id);

        public List<Payment> GetAll();

        public void Add(Payment a);

        public void Update(Payment a);
        public void Delete(string id);

        public Payment GetByAppointmentId(string appointmentId);
    }
}
