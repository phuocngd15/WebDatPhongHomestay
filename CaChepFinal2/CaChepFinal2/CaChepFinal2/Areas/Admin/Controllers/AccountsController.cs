using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaChepFinal2.Data;
using Microsoft.AspNetCore.Mvc;

namespace CaChepFinal2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Accounts.ToList());
        }
    }
}