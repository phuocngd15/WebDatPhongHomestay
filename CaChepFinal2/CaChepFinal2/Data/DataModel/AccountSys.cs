using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CaChepFinal2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaChepFinal2.Data.DataModel
{
    [Authorize(Roles =SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class AccountSys :IdentityUser
    {
    public string Name { get; set; }
    [NotMapped] public bool IsSuperAdmin { get; set; }

    }
}
