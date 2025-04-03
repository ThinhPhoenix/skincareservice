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
                return context.Therapists
                    .Include(t => t.User)
                    .ToList();
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
                return context.Therapists
                    .Include(t => t.User)
                    .FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"TherapistDAO.GetOne - Error retrieving therapist with ID: {id}", ex);
                Console.WriteLine($"Error in GetOne: {ex.Message}");
                return null;
            }
        }

        public void Add(Therapist therapist)
        {
            try
            {
                using var context = new SkinCareDBContext();
                context.Therapists.Add(therapist);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Add: {ex.Message}");
                throw;
            }
        }

        public void Update(Therapist therapist)
        {
            try
            {
                using var context = new SkinCareDBContext();
                var existingTherapist = context.Therapists
                    .Include(t => t.User)
                    .FirstOrDefault(t => t.Id == therapist.Id);
                
                if (existingTherapist != null)
                {
                    // Cập nhật thông tin cơ bản
                    context.Entry(existingTherapist).CurrentValues.SetValues(therapist);
                    
                    // Cập nhật thông tin user nếu có
                    if (therapist.User != null)
                    {
                        var existingUser = context.Users.Find(existingTherapist.UserId);
                        if (existingUser != null)
                        {
                            context.Entry(existingUser).CurrentValues.SetValues(therapist.User);
                        }
                    }
                    
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Update: {ex.Message}");
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                using var context = new SkinCareDBContext();
                
                // Xóa các appointments trước
                var appointments = context.Appointments
                    .Where(a => a.TherapistId == id)
                    .ToList();
                context.Appointments.RemoveRange(appointments);
                
                // Xóa therapist
                var therapist = context.Therapists
                    .Include(t => t.User)
                    .FirstOrDefault(t => t.Id == id);
                
                if (therapist != null)
                {
                    // Xóa therapist
                    context.Therapists.Remove(therapist);
                    
                    // Xóa user liên quan
                    if (therapist.User != null)
                    {
                        context.Users.Remove(therapist.User);
                    }
                    
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete: {ex.Message}");
                throw;
            }
        }

        public List<Appointment> GetTherapistAppointments(string therapistId)
        {
            try
            {
                using var context = new SkinCareDBContext();
                return context.Appointments
                    .Include(a => a.Service)
                    .Include(a => a.Customer)
                    .Include(a => a.Therapist)
                        .ThenInclude(t => t.User)
                    .Where(a => a.TherapistId == therapistId)
                    .OrderByDescending(a => a.AppointmentDateTime)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTherapistAppointments: {ex.Message}");
                return new List<Appointment>();
            }
        }

        public List<Service> GetTherapistServices(string therapistId)
        {
            try
            {
                using var context = new SkinCareDBContext();
                return context.Appointments
                    .Include(a => a.Service)
                    .Where(a => a.TherapistId == therapistId)
                    .Select(a => a.Service)
                    .Distinct()
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTherapistServices: {ex.Message}");
                return new List<Service>();
            }
        }

        public void AddWithUser(Therapist therapist, User user)
        {
            try
            {
                using var context = new SkinCareDBContext();
                using var transaction = context.Database.BeginTransaction();

                try
                {
                    // Thêm user trước
                    context.Users.Add(user);
                    context.SaveChanges();

                    // Gán UserId cho therapist
                    therapist.UserId = user.Id;
                    
                    // Thêm therapist
                    context.Therapists.Add(therapist);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddWithUser: {ex.Message}");
                throw;
            }
        }

        public void UpdateWithUser(Therapist therapist, User user)
        {
            try
            {
                using var context = new SkinCareDBContext();
                using var transaction = context.Database.BeginTransaction();

                try
                {
                    var existingTherapist = context.Therapists
                        .Include(t => t.User)
                        .FirstOrDefault(t => t.Id == therapist.Id);

                    if (existingTherapist != null)
                    {
                        // Cập nhật thông tin therapist
                        context.Entry(existingTherapist).CurrentValues.SetValues(therapist);

                        // Cập nhật user nếu có
                        if (user != null)
                        {
                            var existingUser = context.Users.Find(existingTherapist.UserId);
                            if (existingUser != null)
                            {
                                context.Entry(existingUser).CurrentValues.SetValues(user);
                            }
                        }

                        context.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateWithUser: {ex.Message}");
                throw;
            }
        }

        public void DeleteWithUser(string id)
        {
            try
            {
                using var context = new SkinCareDBContext();
                using var transaction = context.Database.BeginTransaction();

                try
                {
                    // Xóa các appointments trước
                    var appointments = context.Appointments
                        .Where(a => a.TherapistId == id)
                        .ToList();
                    context.Appointments.RemoveRange(appointments);
                    
                    // Xóa therapist
                    var therapist = context.Therapists
                        .Include(t => t.User)
                        .FirstOrDefault(t => t.Id == id);

                    if (therapist != null)
                    {
                        // Xóa therapist
                        context.Therapists.Remove(therapist);
                        
                        // Xóa user liên quan
                        if (therapist.User != null)
                        {
                            context.Users.Remove(therapist.User);
                        }

                        context.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteWithUser: {ex.Message}");
                throw;
            }
        }
    }
}