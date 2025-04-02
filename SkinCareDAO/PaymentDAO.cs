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
                .Where(p => p.PaymentDateTime.Year == year && p.PaymentStatus == "Paid")
                .ToList();

            foreach (var payment in paymentsForYear)
            {
                // Month is 1-based, so subtract 1 for array index
                int monthIndex = payment.PaymentDateTime.Month - 1;
                monthlyRevenue[monthIndex] += payment.Amount;
            }
            return monthlyRevenue;
        }


        public Payment GetOne(string id)
        {
            return _dbContext.Payments
                .SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<Payment> GetAll()
        {
            return _dbContext.Payments

                .ToList();
        }

        public void Add(Payment a)
        {
            Payment cur = GetOne(a.Id);
            if (cur != null)
            {
                throw new Exception();
            }
            _dbContext.Payments.Add(a);
            _dbContext.SaveChanges();
        }

        public void Update(Payment a)
        {
            Payment cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Payment cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.Payments.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }

        public Payment GetByAppointmentId(string appointmentId)
        {
            Payment payment = null;

            try
            {
                Console.WriteLine($"Searching for payment with AppointmentId: {appointmentId}");
                
                payment = _dbContext.Payments
                    .Where(p => p.AppointmentId == appointmentId)
                    .FirstOrDefault();
                
                if (payment != null)
                {
                    Console.WriteLine($"Payment found for appointment {appointmentId}: ID={payment.Id}, Method={payment.PaymentMethod}, Status={payment.PaymentStatus}");
                }
                else
                {
                    Console.WriteLine($"No payment found for appointment {appointmentId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving payment by appointment ID: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw new Exception($"Error retrieving payment by appointment ID: {ex.Message}", ex);
            }

            return payment;
        }
            
    }
}
