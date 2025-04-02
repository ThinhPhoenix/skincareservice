using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO;

namespace SkinCareRepository
{
    public interface ITherapistExpertiseRepository
    {
        Task<List<TherapistExpertise>> GetByTherapistIdAsync(string therapistId);
        Task<List<Service>> GetServicesByTherapistIdAsync(string therapistId);

        public List<Therapist> GetTherapistsByServiceId(string serviceId);
    }
} 