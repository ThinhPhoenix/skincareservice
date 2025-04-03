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

        public List<Therapist> GetAll()
        {
            return TherapistDAO.Instance.GetAll();
        }

        public Therapist GetOne(string id)
        {
            return TherapistDAO.Instance.GetOne(id);
        }

        public void Add(Therapist therapist, User user)
        {
            TherapistDAO.Instance.AddWithUser(therapist, user);
        }

        public void Update(Therapist therapist, User user = null)
        {
            TherapistDAO.Instance.UpdateWithUser(therapist, user);
        }

        public void Delete(string id)
        {
            TherapistDAO.Instance.DeleteWithUser(id);
        }

        public List<Appointment> GetTherapistAppointments(string therapistId)
        {
            return TherapistDAO.Instance.GetTherapistAppointments(therapistId);
        }

        public List<Service> GetTherapistServices(string therapistId)
        {
            return TherapistDAO.Instance.GetTherapistServices(therapistId);
        }
    }
} 