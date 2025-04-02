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
    }
}
