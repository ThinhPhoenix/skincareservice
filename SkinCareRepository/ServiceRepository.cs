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
    public class ServiceRepository : IServiceRepository
    {
        public List<Service> GetAll()
        {
            return ServiceDAO.Instance.GetAll();
           
        }

        public Service GetOne(string id)
        {
            return ServiceDAO.Instance.GetOne(id);
        }

        public void Add(Service a)
        {
            try
            {
                Console.WriteLine($"ServiceRepository.Add - Start with CategoryId: {a.CategoryId}");
                
                // Đảm bảo không còn reference đến ServiceCategory
                a.ServiceCategory = null;
                
                // Đảm bảo ID là null hoặc empty để tạo mới
                if (string.IsNullOrEmpty(a.Id))
                {
                    Console.WriteLine("ServiceRepository.Add - Creating new ID");
                    a.Id = null; // Để DAO tạo GUID mới
                }
                
                Console.WriteLine("ServiceRepository.Add - Calling ServiceDAO.Add");
                ServiceDAO.Instance.Add(a);
                Console.WriteLine("ServiceRepository.Add - Successfully added service");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceRepository.Add - Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"ServiceRepository.Add - Inner error: {ex.InnerException.Message}");
                }
                throw new Exception($"Error in ServiceRepository.Add: {ex.Message}", ex);
            }
        }

        public void Update(Service a)
        {
            ServiceDAO.Instance.Update(a);
        }

        public void Delete(string id)
        {
            ServiceDAO.Instance.Delete(id);
        }
    }
}
