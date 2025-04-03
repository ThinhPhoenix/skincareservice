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
        List<Therapist> GetAll();
        Therapist GetOne(string id);
        void Add(Therapist therapist, User user);
        void Update(Therapist therapist, User user = null);
        void Delete(string id);
        List<Appointment> GetTherapistAppointments(string therapistId);
        List<Service> GetTherapistServices(string therapistId);
    }
} 