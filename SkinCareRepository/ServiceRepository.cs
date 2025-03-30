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

        public Service? GetOne(string id)
        {
            try
            {
                // Refresh context trước khi lấy dữ liệu để đảm bảo dữ liệu mới nhất
                ServiceDAO.Instance.RefreshContext();
                return ServiceDAO.Instance.GetOne(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceRepository.GetOne - Error: {ex.Message}");
                throw;
            }
        }

        public void Add(Service a)
        {
            ServiceDAO.Instance.Add(a);
        }

        public void Update(Service a)
        {
            try
            {
                Console.WriteLine("ServiceRepository.Update - Start updating service");
                // Refresh context trước khi cập nhật để đảm bảo dữ liệu mới nhất
                ServiceDAO.Instance.RefreshContext();
                
                // Cập nhật dịch vụ
                ServiceDAO.Instance.Update(a);
                
                // Refresh context sau khi cập nhật để đảm bảo lần sau lấy dữ liệu mới
                ServiceDAO.Instance.RefreshContext();
                Console.WriteLine("ServiceRepository.Update - Service updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceRepository.Update - Error: {ex.Message}");
                throw;
            }
        }

        public void Delete(string id)
        {
            ServiceDAO.Instance.Delete(id);
        }

        public List<Service> Search(string keyword)
        {
            return ServiceDAO.Instance.Search(keyword);
        }

        public void RefreshData()
        {
            try
            {
                ServiceDAO.Instance.RefreshContext();
                Console.WriteLine("ServiceRepository.RefreshData - Data refreshed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceRepository.RefreshData - Error: {ex.Message}");
                throw;
            }
        }
    }
}
