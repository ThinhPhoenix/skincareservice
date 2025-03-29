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
    public interface IServiceRepository
    {
        public Service? GetOne(string id);

        public List<Service> GetAll();

        public void Add(Service a);

        public void Update(Service a);

        public void Delete(string id);
    }
}
