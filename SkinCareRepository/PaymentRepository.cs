using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;
using SkinCareDAO.Utils;

namespace SkinCareRepository
{
    public class PaymentRepository : IPaymentRepository
    {
        public decimal[] GetDashBoardRevenue(int year)
        {
            LogHelper.LogInfo($"PaymentRepository.GetDashBoardRevenue - Getting revenue dashboard for year: {year}");
            var result = PaymentDAO.Instance.GetDashBoardRevenue(year);
            LogHelper.LogInfo($"PaymentRepository.GetDashBoardRevenue - Successfully retrieved revenue data");
            return result;
        }

        public Payment GetOne(string id)
        {
            LogHelper.LogInfo($"PaymentRepository.GetOne - Retrieving payment with ID: {id}");
            var result = PaymentDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"PaymentRepository.GetOne - Retrieved payment: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public List<Payment> GetAll()
        {
            LogHelper.LogInfo("PaymentRepository.GetAll - Retrieving all payments");
            var result = PaymentDAO.Instance.GetAll();
            LogHelper.LogInfo($"PaymentRepository.GetAll - Retrieved {result.Count} payments");
            return result;
        }

        public void Add(Payment a)
        {
            LogHelper.LogInfo($"PaymentRepository.Add - Adding payment for appointment: {a.AppointmentId}, amount: {a.Amount}");
            PaymentDAO.Instance.Add(a);
            LogHelper.LogInfo($"PaymentRepository.Add - Successfully added payment with ID: {a.Id}");
        }

        public void Update(Payment a)
        {
            LogHelper.LogInfo($"PaymentRepository.Update - Updating payment with ID: {a.Id}");
            PaymentDAO.Instance.Update(a);
            LogHelper.LogInfo($"PaymentRepository.Update - Successfully updated payment");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"PaymentRepository.Delete - Deleting payment with ID: {id}");
            PaymentDAO.Instance.Delete(id);
            LogHelper.LogInfo($"PaymentRepository.Delete - Payment deletion processed");
        }

        public Payment GetByAppointmentId(string appointmentId)
        {
            LogHelper.LogInfo($"PaymentRepository.GetByAppointmentId - Retrieving payment for appointment: {appointmentId}");
            var result = PaymentDAO.Instance.GetByAppointmentId(appointmentId);
            LogHelper.LogInfo($"PaymentRepository.GetByAppointmentId - Retrieved payment: {(result != null ? "Success" : "Not Found")}");
            return result;
        }
    }
}