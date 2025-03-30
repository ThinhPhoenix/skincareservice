using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO;

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
                using var context = new SkinCareDBContext();
                return context.Therapists.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAll: {ex.Message}");
                return new List<Therapist>();
            }
        }

        public Therapist GetOne(string id)
        {
            try
            {
                using var context = new SkinCareDBContext();
                return context.Therapists.FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetOne: {ex.Message}");
                return null;
            }
        }
    }
} 