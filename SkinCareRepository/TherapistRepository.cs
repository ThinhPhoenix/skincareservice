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
    public class TherapistRepository : ITherapistRepository
    {
        public async Task<List<Therapist>> GetAllAsync()
        {
            LogHelper.LogInfo("TherapistRepository.GetAllAsync - Retrieving all therapists");
            var result = TherapistDAO.Instance.GetAll();
            LogHelper.LogInfo($"TherapistRepository.GetAllAsync - Retrieved {result.Count} therapists");
            return await Task.FromResult(result);
        }

        public Therapist GetOne(string id)
        {
            LogHelper.LogInfo($"TherapistRepository.GetOne - Retrieving therapist with ID: {id}");
            var result = TherapistDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"TherapistRepository.GetOne - Retrieved therapist: {(result != null ? "Success" : "Not Found")}");
            return result;
        }
    }
}