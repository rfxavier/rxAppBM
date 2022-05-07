using rxApp.Models;
using System;
using System.Collections.Generic;

namespace rxApp.Domain.Entities
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}