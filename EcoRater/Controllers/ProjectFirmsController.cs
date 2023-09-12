using Microsoft.AspNetCore.Mvc;
using EcoRater.Data;
using EcoRater.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcoRater.Controllers
{
    public class ProjectFirmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectFirmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: List all ProjectFirms
        public IActionResult Index()
        {
            return View(_context.ProjectFirms.ToList());
        }

        // GET: Create new ProjectFirm
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectFirm projectFirm)
        {
            //if (ModelState.IsValid)
            //{
                _context.ProjectFirms.Add(projectFirm);
                _context.SaveChanges();
                Console.WriteLine("New ProjectFirm ID: " + projectFirm.Id);

                return RedirectToAction(nameof(Index));
            //}

            // return View(projectFirm);
        }

        // GET: Edit ProjectFirm by ID
        public IActionResult Edit(int id)
        {
            var projectFirm = _context.ProjectFirms.Find(id);
            if (projectFirm == null)
            {
                return NotFound();
            }
            return View(projectFirm);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProjectFirm projectFirm)
        {
            if (id != projectFirm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectFirm);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency issues here if needed
                }
            }
            return View(projectFirm);
        }

        // GET: Delete ProjectFirm by ID
        public IActionResult Delete(int id)
        {
            var projectFirm = _context.ProjectFirms.Find(id);
            if (projectFirm == null)
            {
                return NotFound();
            }
            return View(projectFirm);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var projectFirm = _context.ProjectFirms.Find(id);

            _ = _context.ProjectFirms.Remove(projectFirm);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Details of ProjectFirm by ID
        public IActionResult Details(int id)
        {
            var projectFirm = _context.ProjectFirms.Find(id);
            if (projectFirm == null)
            {
                return NotFound();
            }
            return View(projectFirm);
        }
    }


}

