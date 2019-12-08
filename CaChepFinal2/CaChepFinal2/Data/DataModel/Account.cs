using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CaChepFinal2.Data.DataModel
{
    public class Account :IdentityUser
    {
    public string Name { get; set; }
    [NotMapped] public bool IsSuperAdmin { get; set; }

    }
}
