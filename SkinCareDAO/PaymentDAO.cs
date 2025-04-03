using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

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
            try
            {
                LogHelper.LogInfo($"PaymentDAO.GetDashBoardRevenue - Retrieving revenue data for year: {year}");

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

                LogHelper.LogInfo($"PaymentDAO.GetDashBoardRevenue - Successfully retrieved revenue data for year: {year}");
                return monthlyRevenue;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"PaymentDAO.GetDashBoardRevenue - Error retrieving revenue data for year: {year}", ex);
                throw;
            }
        }

        public Payment GetOne(string id)
        {
            try
            {
                LogHelper.LogInfo($"PaymentDAO.GetOne - Retrieving payment with ID: {id}");

                var payment = _dbContext.Payments
                    .SingleOrDefault(a => a.Id.Equals(id));

                LogHelper.LogInfo($"PaymentDAO.GetOne - Payment found: {(payment != null ? "Yes" : "No")}");
                return payment;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"PaymentDAO.GetOne - Error retrieving payment with ID: {id}", ex);
                throw;
            }
        }

        public List<Payment> GetAll()
        {
            try
            {
                LogHelper.LogInfo("PaymentDAO.GetAll - Retrieving all payments");

                var payments = _dbContext.Payments.ToList();

                LogHelper.LogInfo($"PaymentDAO.GetAll - Retrieved {payments.Count} payments");
                return payments;
            }
            catch (Exception ex)
            {
                LogHelper.LogError("PaymentDAO.GetAll - Error retrieving all payments", ex);
                throw;
            }
        }

        public void Add(Payment a)
        {
            try
            {
                LogHelper.LogInfo($"PaymentDAO.Add - Adding new payment for appointment: {a.AppointmentId}, amount: {a.Amount}");

                if (!string.IsNullOrEmpty(a.Id))
                {
                    Payment cur = GetOne(a.Id);
                    if (cur != null)
                    {
                        LogHelper.LogWarning($"PaymentDAO.Add - Payment with ID {a.Id} already exists");
                        throw new Exception($"Payment with ID {a.Id} already exists");
                    }
                }
                else
                {
                    a.Id = Guid.NewGuid().ToString();
                    LogHelper.LogInfo($"PaymentDAO.Add - Generated new payment ID: {a.Id}");
                }

                _dbContext.Payments.Add(a);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"PaymentDAO.Add - Successfully added payment with ID: {a.Id} for amount: {a.Amount}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError("PaymentDAO.Add - Error adding payment", ex);
                throw;
            }
        }

        public void Update(Payment a)
        {
            try
            {
                LogHelper.LogInfo($"PaymentDAO.Update - Updating payment with ID: {a.Id}");

                Payment cur = GetOne(a.Id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"PaymentDAO.Update - Payment with ID {a.Id} not found");
                    throw new Exception($"Payment with ID {a.Id} not found");
                }

                _dbContext.Entry(cur).CurrentValues.SetValues(a);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"PaymentDAO.Update - Successfully updated payment with ID: {a.Id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"PaymentDAO.Update - Error updating payment with ID: {a.Id}", ex);
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                LogHelper.LogInfo($"PaymentDAO.Delete - Deleting payment with ID: {id}");

                Payment cur = GetOne(id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"PaymentDAO.Delete - Payment with ID {id} not found");
                    return;
                }

                _dbContext.Payments.Remove(cur);
                _dbContext.SaveChanges();

                LogHelper.LogInfo($"PaymentDAO.Delete - Successfully deleted payment with ID: {id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"PaymentDAO.Delete - Error deleting payment with ID: {id}", ex);
                throw;
            }
        }

        public Payment GetByAppointmentId(string appointmentId)
        {
            try
            {
                LogHelper.LogInfo($"PaymentDAO.GetByAppointmentId - Searching for payment with AppointmentId: {appointmentId}");

                var payment = _dbContext.Payments
                    .Where(p => p.AppointmentId == appointmentId)
                    .FirstOrDefault();

                if (payment != null)
                {
                    LogHelper.LogInfo($"PaymentDAO.GetByAppointmentId - Payment found for appointment {appointmentId}: ID={payment.Id}, Method={payment.PaymentMethod}, Status={payment.PaymentStatus}");
                }
                else
                {
                    LogHelper.LogWarning($"PaymentDAO.GetByAppointmentId - No payment found for appointment {appointmentId}");
                }

                return payment;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"PaymentDAO.GetByAppointmentId - Error retrieving payment by appointment ID: {appointmentId}", ex);
                throw new Exception($"Error retrieving payment by appointment ID: {ex.Message}", ex);
            }
        }
    }
}