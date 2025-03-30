using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;

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
            return _dbContext.Services
                .SingleOrDefault(a => a.Id.Equals(id));
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
            Service cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            Service cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.Services.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }


    }
}
