using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkinCareBussinessObject;
using SkinCareDAO;

namespace SkinCareRepository
{
    public class ServiceCategoryDAO
    {
        private SkinCareDBContext _dbContext;
        private static ServiceCategoryDAO instance;

        public ServiceCategoryDAO()
        {
            _dbContext = new SkinCareDBContext();
        }

        public static ServiceCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceCategoryDAO();
                }
                return instance;
            }
        }

        public ServiceCategory GetOne(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return _dbContext.ServiceCategories.SingleOrDefault(a => a.Id.Equals(id));
        }

        public List<ServiceCategory> GetAll()
        {
            return _dbContext.ServiceCategories.ToList();
        }

        public void Add(ServiceCategory a)
        {
            if (!string.IsNullOrEmpty(a.Id))
            {
                ServiceCategory cur = GetOne(a.Id);
                if (cur != null)
                {
                    throw new Exception($"Danh mục dịch vụ với ID {a.Id} đã tồn tại");
                }
            }
            else
            {
                a.Id = Guid.NewGuid().ToString();
            }
            
            try
            {
                Console.WriteLine("Adding category: " + a.CategoryName);
                _dbContext.ServiceCategories.Add(a);
                _dbContext.SaveChanges();
                Console.WriteLine("Category added successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm danh mục dịch vụ: {ex.Message}", ex);
            }
        }

        public void Update(ServiceCategory a)
        {
            ServiceCategory cur = GetOne(a.Id);
            if (cur == null)
            {
                throw new Exception();
            }
            _dbContext.Entry(cur).CurrentValues.SetValues(a);
            _dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            ServiceCategory cur = GetOne(id);
            if (cur != null)
            {
                _dbContext.ServiceCategories.Remove(cur);
                _dbContext.SaveChanges(); // Delete the object
            }
        }
    }
}
