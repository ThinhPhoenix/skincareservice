using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class PaymentDAO
    {

        private SkinCareDBContext _dbContext;
        private static PaymentDAO instance;

        public PaymentDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentDAO();
                }
                return instance;
            }
        }

        public decimal[] GetDashBoardRevenue(int year)
        {
            decimal[] monthlyRevenue = new decimal[12];

            var paymentsForYear = _dbContext.Payments
                .Where(p => p.PaymentDateTime.Year == year && p.PaymentStatus == "PAID")
                .ToList();

            foreach (var payment in paymentsForYear)
            {
                // Month is 1-based, so subtract 1 for array index
                int monthIndex = payment.PaymentDateTime.Month - 1;
                monthlyRevenue[monthIndex] += payment.Amount;
            }
            return monthlyRevenue;
        }
    }
}
