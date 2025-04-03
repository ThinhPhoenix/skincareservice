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
    public class ServiceRepository : IServiceRepository
    {
        public List<Service> GetAll()
        {
            LogHelper.LogInfo("ServiceRepository.GetAll - Retrieving all services");
            var result = ServiceDAO.Instance.GetAll();
            LogHelper.LogInfo($"ServiceRepository.GetAll - Retrieved {result.Count} services");
            return result;
        }

        public Service? GetOne(string id)
        {
            try
            {
                LogHelper.LogInfo($"ServiceRepository.GetOne - Retrieving service with ID: {id}");
                // Refresh context trước khi lấy dữ liệu để đảm bảo dữ liệu mới nhất
                ServiceDAO.Instance.RefreshContext();
                var result = ServiceDAO.Instance.GetOne(id);
                LogHelper.LogInfo($"ServiceRepository.GetOne - Retrieved service: {(result != null ? "Success" : "Not Found")}");
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceRepository.GetOne - Error: {ex.Message}", ex);
                Console.WriteLine($"ServiceRepository.GetOne - Error: {ex.Message}");
                throw;
            }
        }

        public void Add(Service a)
        {
            LogHelper.LogInfo($"ServiceRepository.Add - Adding service: {a.ServiceName}");
            ServiceDAO.Instance.Add(a);
            LogHelper.LogInfo($"ServiceRepository.Add - Successfully added service with ID: {a.Id}");
        }

        public void Update(Service a)
        {
            try
            {
                LogHelper.LogInfo($"ServiceRepository.Update - Updating service with ID: {a.Id}");
                // Refresh context trước khi cập nhật để đảm bảo dữ liệu mới nhất
                ServiceDAO.Instance.RefreshContext();

                // Cập nhật dịch vụ
                ServiceDAO.Instance.Update(a);

                // Refresh context sau khi cập nhật để đảm bảo lần sau lấy dữ liệu mới
                ServiceDAO.Instance.RefreshContext();
                LogHelper.LogInfo($"ServiceRepository.Update - Successfully updated service with ID: {a.Id}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceRepository.Update - Error: {ex.Message}", ex);
                Console.WriteLine($"ServiceRepository.Update - Error: {ex.Message}");
                throw;
            }
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"ServiceRepository.Delete - Deleting service with ID: {id}");
            ServiceDAO.Instance.Delete(id);
            LogHelper.LogInfo($"ServiceRepository.Delete - Service deletion processed");
        }

        public List<Service> Search(string keyword)
        {
            LogHelper.LogInfo($"ServiceRepository.Search - Searching services with keyword: {keyword}");
            var result = ServiceDAO.Instance.Search(keyword);
            LogHelper.LogInfo($"ServiceRepository.Search - Found {result.Count} services matching '{keyword}'");
            return result;
        }

        public void RefreshData()
        {
            try
            {
                LogHelper.LogInfo("ServiceRepository.RefreshData - Refreshing service data");
                ServiceDAO.Instance.RefreshContext();
                LogHelper.LogInfo("ServiceRepository.RefreshData - Data refreshed successfully");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceRepository.RefreshData - Error: {ex.Message}", ex);
                Console.WriteLine($"ServiceRepository.RefreshData - Error: {ex.Message}");
                throw;
            }
        }
    }
}