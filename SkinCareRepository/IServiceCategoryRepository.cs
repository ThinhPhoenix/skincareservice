using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkinCareBussinessObject;

namespace SkinCareRepository
{
    public interface IServiceCategoryRepository
    {
        public ServiceCategory GetOne(string id);

        public List<ServiceCategory> GetAll();

        public void Add(ServiceCategory a);

        public void Update(ServiceCategory a);
        public void Delete(string id);
    }
}
