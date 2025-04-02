using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

namespace SkinCareDAO
{
    public class TherapistExpertiseDAO
    {
        private static TherapistExpertiseDAO? instance;
        private static readonly object instanceLock = new();

        public static TherapistExpertiseDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new TherapistExpertiseDAO();
                    return instance;
                }
            }
        }

        public List<TherapistExpertise> GetByTherapistId(string therapistId)
        {
            try
            {
                using var context = new SkinCareDBContext();
                return context.TherapistExpertises
                    .Where(te => te.TherapistId == therapistId)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByTherapistId: {ex.Message}");
                return [];
            }
        }
        
        public List<Service> GetServicesByTherapistId(string therapistId)
        {
            try
            {
                using var context = new SkinCareDBContext();
                // Lấy danh sách ServiceId từ TherapistExpertise
                var serviceIds = context.TherapistExpertises
                    .Where(te => te.TherapistId == therapistId)
                    .Select(te => te.ServiceId)
                    .ToList();
                
                // Lấy thông tin các Service có Id nằm trong danh sách serviceIds
                return context.Services
                    .Where(s => serviceIds.Contains(s.Id))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetServicesByTherapistId: {ex.Message}");
                return [];
            }
        }

        public List<Therapist> GetTherapistsByServiceId(string serviceId)
        {
            try
            {
                using var context = new SkinCareDBContext();

                // Get therapist IDs from TherapistExpertise table for the specified service
                var therapistIds = context.TherapistExpertises
                    .Where(te => te.ServiceId == serviceId)
                    .Select(te => te.TherapistId)
                    .ToList();

                // Get therapist details for those IDs
                return context.Therapists
                    .Where(t => therapistIds.Contains(t.Id))
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTherapistsByServiceId: {ex.Message}");
                return [];
            }
        }


    }
} 