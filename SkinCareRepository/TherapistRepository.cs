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
    public class TherapistRepository : ITherapistRepository
    {
        public Task<List<Therapist>> GetAllAsync()
        {
            var result = TherapistDAO.Instance.GetAll();
            return Task.FromResult(result);
        }

        public Task<Therapist> GetOneAsync(string id)
        {
            var result = TherapistDAO.Instance.GetOne(id);
            return Task.FromResult(result);
        }
    }
} 