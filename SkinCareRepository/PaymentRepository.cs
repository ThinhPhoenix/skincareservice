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
    public class PaymentRepository : IPaymentRepository
    {
        public decimal[] GetDashBoardRevenue(int year)
        {
            return PaymentDAO.Instance.GetDashBoardRevenue(year);
        }


        public Payment GetOne(string id) => PaymentDAO.Instance.GetOne(id);

        public List<Payment> GetAll() => PaymentDAO.Instance.GetAll();

        public void Add(Payment a) => PaymentDAO.Instance.Add(a);

        public void Update(Payment a) => PaymentDAO.Instance.Update(a);
        public void Delete(string id) => PaymentDAO.Instance.Delete(id);

    }
}
