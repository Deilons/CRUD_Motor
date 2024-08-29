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

        [Route("edit/{id}")]

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var motorInfo = await _context.MotorInfos.FindAsync(id);
            if (motorInfo == null)
            {
                return NotFound();
            }
            return View(motorInfo);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Brand,Model,Displacement,Cylinders,Aspiration,HorsePower,Torque,FuelType,isTurbocharged,Year")] MotorInfo motorInfo)
        {
            if (id != motorInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorInfoExists(motorInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(motorInfo);
            }
        }

        [Route("delete/{id}")]

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorInfo = await _context.MotorInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorInfo == null)
            {
                return NotFound();
            }

            return View(motorInfo);
        }

        [HttpPost("delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motorInfo = await _context.MotorInfos.FindAsync(id);
            _context.MotorInfos.Remove(motorInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //details
        [Route("details/{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorInfo = await _context.MotorInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorInfo == null)
            {
                return NotFound();
            }

            return View(motorInfo);
        }
        

        private bool MotorInfoExists(Guid id)
        {
            return _context.MotorInfos.Any(e => e.Id == id);
        }
    }
}
