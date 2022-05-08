﻿using rxAppBM.Models;
using System;
using System.Collections.Generic;

namespace rxAppBM.Domain.Entities
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}