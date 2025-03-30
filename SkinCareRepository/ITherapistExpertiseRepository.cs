using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

namespace SkinCareRepository
{
    public interface ITherapistExpertiseRepository
    {
        Task<List<TherapistExpertise>> GetByTherapistIdAsync(string therapistId);
        Task<List<Service>> GetServicesByTherapistIdAsync(string therapistId);
    }
} 