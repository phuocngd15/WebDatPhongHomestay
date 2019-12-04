using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CaChepCosmeticMVC2.Models.DataModels
{
    public partial class Account : IdentityUser
    {
        public string Name { get; set; }
        [NotMapped]
        public bool IsSuperAdmin { get; set; }

    }
}
