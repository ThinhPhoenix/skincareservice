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
    public class TherapistExpertiseRepository : ITherapistExpertiseRepository
    {
        public Task<List<TherapistExpertise>> GetByTherapistIdAsync(string therapistId)
        {
            // Thay đổi để không sử dụng async/await
            var result = TherapistExpertiseDAO.Instance.GetByTherapistId(therapistId);
            return Task.FromResult(result);
        }

        public Task<List<Service>> GetServicesByTherapistIdAsync(string therapistId)
        {
            // Thay đổi để không sử dụng async/await
            var result = TherapistExpertiseDAO.Instance.GetServicesByTherapistId(therapistId);
            return Task.FromResult(result);
        }
        public List<Therapist> GetTherapistsByServiceId(string serviceId) => TherapistExpertiseDAO.Instance.GetTherapistsByServiceId(
            serviceId);
    }
} 