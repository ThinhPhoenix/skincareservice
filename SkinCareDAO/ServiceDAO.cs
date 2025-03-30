using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using Microsoft.EntityFrameworkCore;

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
            // Đảm bảo DbContext được refresh để lấy dữ liệu mới nhất
            try
            {
                Console.WriteLine($"ServiceDAO.GetOne - Fetching service with ID: {id}");
                
                // Tìm service và tải trực tiếp, không sử dụng cache
                var service = _dbContext.Services
                    .AsNoTracking() // Đảm bảo EF không track entity này
                    .SingleOrDefault(a => a.Id.Equals(id));
                    
                Console.WriteLine($"ServiceDAO.GetOne - Service found: {(service != null ? "Yes" : "No")}");
                
                return service;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceDAO.GetOne - Error: {ex.Message}");
                throw;
            }
        }

        public List<Service> GetAll()
        {
            return _dbContext.Services
                .ToList();
        }

        public void Add(Service a)
        {
            try
            {
                Console.WriteLine($"ServiceDAO.Add - Start with service: {a.ServiceName}, CategoryId: {a.CategoryId}");
                
                // Đảm bảo xóa bỏ reference đến ServiceCategory để tránh EF tạo mới
                a.ServiceCategory = null;
                
                // Tạo ID mới nếu chưa có
                if (string.IsNullOrEmpty(a.Id))
                {
                    Console.WriteLine("ServiceDAO.Add - Creating new GUID");
                    a.Id = Guid.NewGuid().ToString();
                }
                else
                {
                    Console.WriteLine($"ServiceDAO.Add - Checking if ID {a.Id} exists");
                    Service cur = GetOne(a.Id);
                    if (cur != null)
                    {
                        throw new Exception("Service with this ID already exists");
                    }
                }
                
                // Kiểm tra xem CategoryId có tồn tại trong database không
                if (!string.IsNullOrEmpty(a.CategoryId))
                {
                    Console.WriteLine($"ServiceDAO.Add - Checking if CategoryId {a.CategoryId} exists");
                    var category = _dbContext.ServiceCategories.Find(a.CategoryId);
                    if (category == null)
                    {
                        throw new Exception($"Category with ID {a.CategoryId} does not exist");
                    }
                    Console.WriteLine($"ServiceDAO.Add - Found category: {category.CategoryName}");
                }
                
                // Thêm vào context và lưu
                Console.WriteLine("ServiceDAO.Add - Adding to context");
                _dbContext.Services.Add(a);
                
                Console.WriteLine("ServiceDAO.Add - Saving changes");
                _dbContext.SaveChanges();
                Console.WriteLine("ServiceDAO.Add - Successfully saved service");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                Console.WriteLine($"ServiceDAO.Add - DbUpdateException: {dbEx.Message}");
                if (dbEx.InnerException != null)
                {
                    Console.WriteLine($"ServiceDAO.Add - Inner exception: {dbEx.InnerException.Message}");
                }
                throw new Exception("Database error while adding service", dbEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceDAO.Add - General exception: {ex.Message}");
                throw;
            }
        }

        public void Update(Service a)
        {
            try
            {
                Console.WriteLine($"ServiceDAO.Update - Start with service ID: {a.Id}");
                
                // Đảm bảo có dữ liệu mới nhất từ DB
                RefreshContext();
                
                // Kiểm tra sự tồn tại của dịch vụ
                Service cur = GetOne(a.Id);
                if (cur == null)
                {
                    throw new Exception($"Không tìm thấy dịch vụ với ID {a.Id}");
                }
                
                // Đảm bảo xóa bỏ reference đến ServiceCategory để tránh EF tạo mới
                a.ServiceCategory = null;
                
                // Kiểm tra xem CategoryId có tồn tại trong database không
                if (!string.IsNullOrEmpty(a.CategoryId))
                {
                    Console.WriteLine($"ServiceDAO.Update - Checking if CategoryId {a.CategoryId} exists");
                    var category = _dbContext.ServiceCategories.Find(a.CategoryId);
                    if (category == null)
                    {
                        throw new Exception($"Danh mục với ID {a.CategoryId} không tồn tại");
                    }
                }
                
                Console.WriteLine("ServiceDAO.Update - Creating a tracked entity copy");
                
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
                Console.WriteLine($"ServiceDAO.Update - Updated values: Name={trackedEntity.ServiceName}, Price={trackedEntity.Price}, CategoryId={trackedEntity.CategoryId}");
                
                // Cập nhật một cách rõ ràng
                _dbContext.Attach(trackedEntity);
                _dbContext.Entry(trackedEntity).State = EntityState.Modified;
                
                Console.WriteLine("ServiceDAO.Update - Saving changes");
                _dbContext.SaveChanges();
                
                // Detach entity sau khi lưu để tránh các vấn đề về tracking
                _dbContext.Entry(trackedEntity).State = EntityState.Detached;
                
                // Refresh DbContext để đảm bảo không có vấn đề với dữ liệu trong cache
                RefreshContext();
                
                Console.WriteLine("ServiceDAO.Update - Successfully updated service");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                Console.WriteLine($"ServiceDAO.Update - DbUpdateException: {dbEx.Message}");
                if (dbEx.InnerException != null)
                {
                    Console.WriteLine($"ServiceDAO.Update - Inner exception: {dbEx.InnerException.Message}");
                }
                throw new Exception("Lỗi cơ sở dữ liệu khi cập nhật dịch vụ", dbEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceDAO.Update - General exception: {ex.Message}");
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                Console.WriteLine($"ServiceDAO.Delete - Start with service ID: {id}");
                
                // Kiểm tra sự tồn tại của dịch vụ
                Service cur = GetOne(id);
                if (cur == null)
                {
                    Console.WriteLine($"ServiceDAO.Delete - Service with ID {id} not found");
                    return; // Không cần throw exception nếu không tìm thấy để xóa
                }
                
                // Kiểm tra ràng buộc khóa ngoại trước khi xóa (nếu cần)
                // Ví dụ: kiểm tra xem có ServiceRecommendation nào liên quan không
                var hasRecommendations = _dbContext.ServiceRecommendations.Any(sr => sr.ServiceId == id);
                if (hasRecommendations)
                {
                    throw new Exception("Không thể xóa dịch vụ vì có khuyến nghị dịch vụ liên quan");
                }
                
                // Kiểm tra ràng buộc khác (ví dụ: Appointment, ...)
                
                Console.WriteLine("ServiceDAO.Delete - Removing entity");
                _dbContext.Services.Remove(cur);
                
                Console.WriteLine("ServiceDAO.Delete - Saving changes");
                _dbContext.SaveChanges();
                Console.WriteLine("ServiceDAO.Delete - Successfully deleted service");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                Console.WriteLine($"ServiceDAO.Delete - DbUpdateException: {dbEx.Message}");
                if (dbEx.InnerException != null)
                {
                    Console.WriteLine($"ServiceDAO.Delete - Inner exception: {dbEx.InnerException.Message}");
                }
                throw new Exception("Lỗi cơ sở dữ liệu khi xóa dịch vụ", dbEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceDAO.Delete - General exception: {ex.Message}");
                throw;
            }
        }

        public List<Service> Search(string keyword)
        {
            try
            {
                Console.WriteLine($"ServiceDAO.Search - Searching for keyword: {keyword}");
                
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return GetAll();
                }
                
                keyword = keyword.ToLower().Trim();
                
                Console.WriteLine("ServiceDAO.Search - Executing search query");
                return _dbContext.Services
                    .Where(s => 
                        (s.ServiceName != null && s.ServiceName.ToLower().Contains(keyword)) ||
                        (s.Description != null && s.Description.ToLower().Contains(keyword)) ||
                        (s.Prerequisites != null && s.Prerequisites.ToLower().Contains(keyword)) ||
                        (s.Aftercare != null && s.Aftercare.ToLower().Contains(keyword))
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceDAO.Search - Exception: {ex.Message}");
                throw new Exception("Lỗi khi tìm kiếm dịch vụ", ex);
            }
        }

        // Tạo một phương thức khởi tạo lại DbContext để đảm bảo dữ liệu mới
        public void RefreshContext()
        {
            try
            {
                Console.WriteLine("ServiceDAO.RefreshContext - Refreshing DbContext");
                // Giải phóng DbContext hiện tại
                _dbContext.Dispose();
                // Tạo mới DbContext
                _dbContext = new SkinCareDBContext();
                Console.WriteLine("ServiceDAO.RefreshContext - DbContext refreshed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ServiceDAO.RefreshContext - Error: {ex.Message}");
                throw;
            }
        }

    }
}
