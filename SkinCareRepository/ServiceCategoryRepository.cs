using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;
using SkinCareDAO.Utils;

namespace SkinCareRepository
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {
        public ServiceCategory GetOne(string id)
        {
            LogHelper.LogInfo($"ServiceCategoryRepository.GetOne - Retrieving service category with ID: {id}");
            var result = ServiceCategoryDAO.Instance.GetOne(id);
            LogHelper.LogInfo($"ServiceCategoryRepository.GetOne - Retrieved category: {(result != null ? "Success" : "Not Found")}");
            return result;
        }

        public List<ServiceCategory> GetAll()
        {
            LogHelper.LogInfo("ServiceCategoryRepository.GetAll - Retrieving all service categories");
            var result = ServiceCategoryDAO.Instance.GetAll();
            LogHelper.LogInfo($"ServiceCategoryRepository.GetAll - Retrieved {result.Count} categories");
            return result;
        }

        public void Add(ServiceCategory a)
        {
            LogHelper.LogInfo($"ServiceCategoryRepository.Add - Adding service category: {a.CategoryName}");
            ServiceCategoryDAO.Instance.Add(a);
            LogHelper.LogInfo($"ServiceCategoryRepository.Add - Successfully added category with ID: {a.Id}");
        }

        public void Update(ServiceCategory a)
        {
            LogHelper.LogInfo($"ServiceCategoryRepository.Update - Updating service category with ID: {a.Id}");
            ServiceCategoryDAO.Instance.Update(a);
            LogHelper.LogInfo($"ServiceCategoryRepository.Update - Successfully updated category");
        }

        public void Delete(string id)
        {
            LogHelper.LogInfo($"ServiceCategoryRepository.Delete - Deleting service category with ID: {id}");
            ServiceCategoryDAO.Instance.Delete(id);
            LogHelper.LogInfo($"ServiceCategoryRepository.Delete - Category deletion processed");
        }
    }
}