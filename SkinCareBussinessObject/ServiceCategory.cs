using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinCareBussinessObject
{
    public class ServiceCategory
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
