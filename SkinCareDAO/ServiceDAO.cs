using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using Microsoft.EntityFrameworkCore;
using SkinCareDAO.Utils;

namespace SkinCareDAO
{
    public class ServiceDAO
    {
        private SkinCareDBContext _dbContext;
        private static ServiceDAO instance;

        public ServiceDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static ServiceDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceDAO();
                }
                return instance;
            }
        }

        public Service? GetOne(string id)
        {
            try
            {
                LogHelper.LogInfo($"ServiceDAO.GetOne - Fetching service with ID: {id}");

                var service = _dbContext.Services
                    .AsNoTracking() // Đảm bảo EF không track entity này
                    .SingleOrDefault(a => a.Id.Equals(id));

                LogHelper.LogInfo($"ServiceDAO.GetOne - Service found: {(service != null ? "Yes" : "No")}");

                return service;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceDAO.GetOne - Error retrieving service with ID: {id}", ex);
                throw;
            }
        }

        public List<Service> GetAll()
        {
            try
            {
                LogHelper.LogInfo("ServiceDAO.GetAll - Retrieving all services");
                return _dbContext.Services.ToList();
            }
            catch (Exception ex)
            {
                LogHelper.LogError("ServiceDAO.GetAll - Error retrieving all services", ex);
                throw;
            }
        }

        public void Add(Service a)
        {
            try
            {
                LogHelper.LogInfo($"ServiceDAO.Add - Start with service: {a.ServiceName}, CategoryId: {a.CategoryId}");

                // Đảm bảo xóa bỏ reference đến ServiceCategory để tránh EF tạo mới
                a.ServiceCategory = null;

                // Tạo ID mới nếu chưa có
                if (string.IsNullOrEmpty(a.Id))
                {
                    LogHelper.LogInfo("ServiceDAO.Add - Creating new GUID");
                    a.Id = Guid.NewGuid().ToString();
                }
                else
                {
                    LogHelper.LogInfo($"ServiceDAO.Add - Checking if ID {a.Id} exists");
                    Service cur = GetOne(a.Id);
                    if (cur != null)
                    {
                        LogHelper.LogWarning($"ServiceDAO.Add - Service with ID {a.Id} already exists");
                        throw new Exception("Service with this ID already exists");
                    }
                }

                // Kiểm tra xem CategoryId có tồn tại trong database không
                if (!string.IsNullOrEmpty(a.CategoryId))
                {
                    LogHelper.LogInfo($"ServiceDAO.Add - Checking if CategoryId {a.CategoryId} exists");
                    var category = _dbContext.ServiceCategories.Find(a.CategoryId);
                    if (category == null)
                    {
                        LogHelper.LogWarning($"ServiceDAO.Add - Category with ID {a.CategoryId} does not exist");
                        throw new Exception($"Category with ID {a.CategoryId} does not exist");
                    }
                    LogHelper.LogInfo($"ServiceDAO.Add - Found category: {category.CategoryName}");
                }

                // Thêm vào context và lưu
                LogHelper.LogInfo("ServiceDAO.Add - Adding to context");
                _dbContext.Services.Add(a);

                LogHelper.LogInfo("ServiceDAO.Add - Saving changes");
                _dbContext.SaveChanges();
                LogHelper.LogInfo("ServiceDAO.Add - Successfully saved service");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                LogHelper.LogError($"ServiceDAO.Add - DbUpdateException", dbEx);
                throw new Exception("Database error while adding service", dbEx);
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceDAO.Add - General exception", ex);
                throw;
            }
        }

        public void Update(Service a)
        {
            try
            {
                LogHelper.LogInfo($"ServiceDAO.Update - Start with service ID: {a.Id}");

                // Đảm bảo có dữ liệu mới nhất từ DB
                RefreshContext();

                // Kiểm tra sự tồn tại của dịch vụ
                Service cur = GetOne(a.Id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"ServiceDAO.Update - Service with ID {a.Id} not found");
                    throw new Exception($"Service with ID {a.Id} not found");
                }

                // Đảm bảo xóa bỏ reference đến ServiceCategory để tránh EF tạo mới
                a.ServiceCategory = null;

                // Kiểm tra xem CategoryId có tồn tại trong database không
                if (!string.IsNullOrEmpty(a.CategoryId))
                {
                    LogHelper.LogInfo($"ServiceDAO.Update - Checking if CategoryId {a.CategoryId} exists");
                    var category = _dbContext.ServiceCategories.Find(a.CategoryId);
                    if (category == null)
                    {
                        LogHelper.LogWarning($"ServiceDAO.Update - Category with ID {a.CategoryId} does not exist");
                        throw new Exception($"Category with ID {a.CategoryId} does not exist");
                    }
                }

                LogHelper.LogInfo("ServiceDAO.Update - Creating a tracked entity copy");

                // Tạo một entity mới được tracked bởi DbContext với ID giống entity cần update
                var trackedEntity = new Service
                {
                    Id = a.Id,
                    ServiceName = a.ServiceName,
                    Description = a.Description ?? string.Empty,
                    CategoryId = a.CategoryId,
                    Price = a.Price,
                    DurationMinutes = a.DurationMinutes,
                    IsActive = a.IsActive,
                    Prerequisites = a.Prerequisites ?? string.Empty,
                    Aftercare = a.Aftercare ?? string.Empty
                };

                // Kiểm tra và log dữ liệu sau khi cập nhật
                LogHelper.LogInfo($"ServiceDAO.Update - Updated values: Name={trackedEntity.ServiceName}, Price={trackedEntity.Price}, CategoryId={trackedEntity.CategoryId}");

                // Cập nhật một cách rõ ràng
                _dbContext.Attach(trackedEntity);
                _dbContext.Entry(trackedEntity).State = EntityState.Modified;

                LogHelper.LogInfo("ServiceDAO.Update - Saving changes");
                _dbContext.SaveChanges();

                // Detach entity sau khi lưu để tránh các vấn đề về tracking
                _dbContext.Entry(trackedEntity).State = EntityState.Detached;

                // Refresh DbContext để đảm bảo không có vấn đề với dữ liệu trong cache
                RefreshContext();

                LogHelper.LogInfo("ServiceDAO.Update - Successfully updated service");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                LogHelper.LogError($"ServiceDAO.Update - DbUpdateException", dbEx);
                throw new Exception("Database error while updating service", dbEx);
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceDAO.Update - General exception", ex);
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                LogHelper.LogInfo($"ServiceDAO.Delete - Start with service ID: {id}");

                // Kiểm tra sự tồn tại của dịch vụ
                Service cur = GetOne(id);
                if (cur == null)
                {
                    LogHelper.LogWarning($"ServiceDAO.Delete - Service with ID {id} not found");
                    return; // Không cần throw exception nếu không tìm thấy để xóa
                }

                // Kiểm tra ràng buộc khóa ngoại trước khi xóa (nếu cần)
                // Ví dụ: kiểm tra xem có ServiceRecommendation nào liên quan không
                var hasRecommendations = _dbContext.ServiceRecommendations.Any(sr => sr.ServiceId == id);
                if (hasRecommendations)
                {
                    LogHelper.LogWarning($"ServiceDAO.Delete - Cannot delete service with ID {id} due to related recommendations");
                    throw new Exception("Cannot delete service due to related recommendations");
                }

                LogHelper.LogInfo("ServiceDAO.Delete - Removing entity");
                _dbContext.Services.Remove(cur);

                LogHelper.LogInfo("ServiceDAO.Delete - Saving changes");
                _dbContext.SaveChanges();
                LogHelper.LogInfo("ServiceDAO.Delete - Successfully deleted service");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                LogHelper.LogError($"ServiceDAO.Delete - DbUpdateException", dbEx);
                throw new Exception("Database error while deleting service", dbEx);
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceDAO.Delete - General exception", ex);
                throw;
            }
        }

        public List<Service> Search(string keyword)
        {
            try
            {
                LogHelper.LogInfo($"ServiceDAO.Search - Searching for keyword: {keyword}");

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    LogHelper.LogInfo("ServiceDAO.Search - Empty keyword, returning all services");
                    return GetAll();
                }

                keyword = keyword.ToLower().Trim();

                LogHelper.LogInfo("ServiceDAO.Search - Executing search query");
                var results = _dbContext.Services
                    .Where(s =>
                        (s.ServiceName != null && s.ServiceName.ToLower().Contains(keyword)) ||
                        (s.Description != null && s.Description.ToLower().Contains(keyword)) ||
                        (s.Prerequisites != null && s.Prerequisites.ToLower().Contains(keyword)) ||
                        (s.Aftercare != null && s.Aftercare.ToLower().Contains(keyword))
                    )
                    .ToList();

                LogHelper.LogInfo($"ServiceDAO.Search - Found {results.Count} results");
                return results;
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceDAO.Search - Exception when searching for: {keyword}", ex);
                throw;
            }
        }

        // Tạo một phương thức khởi tạo lại DbContext để đảm bảo dữ liệu mới
        public void RefreshContext()
        {
            try
            {
                LogHelper.LogInfo("ServiceDAO.RefreshContext - Refreshing DbContext");
                // Giải phóng DbContext hiện tại
                _dbContext.Dispose();
                // Tạo mới DbContext
                _dbContext = new SkinCareDBContext();
                LogHelper.LogInfo("ServiceDAO.RefreshContext - DbContext refreshed successfully");
            }
            catch (Exception ex)
            {
                LogHelper.LogError($"ServiceDAO.RefreshContext - Error refreshing context", ex);
                throw;
            }
        }
    }
}