using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

namespace SkinCareRepository
{
    public interface ITherapistRepository
    {
        Task<List<Therapist>> GetAllAsync();
        Task<Therapist> GetOneAsync(string id);
    }
} 