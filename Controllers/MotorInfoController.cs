using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Motor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CRUD_Motor.Controllers
{
    [Route("[controller]")]
    public class MotorInfoController : Controller
    {
        private readonly ILogger<MotorInfoController> _logger;
        private readonly ApplicationDBContext _context;

        public MotorInfoController(ILogger<MotorInfoController> logger, ApplicationDBContext Context)
        {
            _logger = logger;
            _context = Context;
        }

        [Route("[action]")]


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public async Task<IActionResult> Index()
        {
            var motorInfos = await _context.MotorInfos.ToListAsync();
            return View(motorInfos);
        }
    }
}