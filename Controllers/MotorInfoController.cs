using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Motor.Data;
using CRUD_Motor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;

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

        // GET: MotorInfo/Create
        [Route("create")]
        public IActionResult Create()
        {

            return View();
        }

        // POST: MotorInfo/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MotorInfo motorInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogError("Error creating new motor");
                return View(motorInfo);
            }
        }
    }
}
