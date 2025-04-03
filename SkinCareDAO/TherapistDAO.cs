using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

namespace SkinCareDAO
{
    public class TherapistDAO
    {
        private static TherapistDAO instance = null;
        private static readonly object instanceLock = new object();

        public static TherapistDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TherapistDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Therapist> GetAll()
        {
            try
            {
                LogHelper.LogInfo("TherapistDAO.GetAll - Retrieving all therapists");

                using var context = new SkinCareDBContext();
                var therapists = context.Therapists.ToList();

                LogHelper.LogInfo($"TherapistDAO.GetAll - Retrieved {therapists.Count} therapists");

                return therapists;
            }
            catch (Exception ex)
            {
                LogHelper.LogError("TherapistDAO.GetAll - Error retrieving therapists", ex);
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                return new List<Therapist>();
            }
        }

        public Therapist GetOne(string id)
        {
            try
            {
                LogHelper.LogInfo($"TherapistDAO.GetOne - Retrieving therapist with ID: {id}");

                using var context = new SkinCareDBContext();
                var therapist = context.Therapists.FirstOrDefault(t => t.Id == id);

                LogHelper.LogInfo($"TherapistDAO.GetOne - Therapist found: {(therapist != null ? "Yes" : "No")}");

                return therapist;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"TherapistDAO.GetOne - Error retrieving therapist with ID: {id}", ex);
                Console.WriteLine($"Error in GetOne: {ex.Message}");
                return null;
            }
        }
    }
}