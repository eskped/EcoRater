using Microsoft.AspNetCore.Mvc;
using EcoRater.Data;
using EcoRater.Models;
using System.Linq;
using EcoRater.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Text;

namespace EcoRater.Controllers
{
    public class ProjectFirmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOpenAIService _openAiService;

        public ProjectFirmsController(IOpenAIService openAiService, ApplicationDbContext context)
        {
            _openAiService = openAiService;
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

        [HttpPost]
        public async Task<IActionResult> SaveAnswers(int id, List<string> answers)
        {
            if (answers == null || !answers.Any())
            {
                ModelState.AddModelError("", "No answers provided.");
                return View("SustainabilityAssessment"); // Redirect back to the same view if there's an error.
            }

            var projectFirm = await _context.ProjectFirms.FindAsync(id);

            if (projectFirm == null)
            {
                return NotFound("ProjectFirm not found.");
            }

            // Here, I'm saving answers as a single string separated by a special character, e.g., '|'.
            // This is a simplistic approach and might not be suitable for more complex requirements.
            projectFirm.UserAnswers = string.Join("\n", answers);

            _context.Update(projectFirm);
            await _context.SaveChangesAsync();

            // After saving, redirect to a confirmation page or another appropriate action.
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult InitialQuestions(int id)
        {
            var projectFirm = _context.ProjectFirms.Find(id);
            if (projectFirm == null)
            {
                return NotFound();
            }
            return View(projectFirm); ;
        }

        [HttpPost]
        public async Task<IActionResult> InitialQuestions(ProjectFirm model)
        {

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var originalEntity = await _context.ProjectFirms.SingleOrDefaultAsync(pf => pf.Id == model.Id);

                if (originalEntity == null)
                {
                    ModelState.AddModelError(string.Empty, "Entity not found.");
                    return View(model);
                }


                originalEntity.UserId = userId;
                originalEntity.Industry = model.Industry;
                originalEntity.BusinessNature = model.BusinessNature;
                originalEntity.BusinessSize = model.BusinessSize;
                originalEntity.OperationalRegions = model.OperationalRegions;
                originalEntity.ManufacturingInvolved = model.ManufacturingInvolved;
                originalEntity.SourcingFromOutside = model.SourcingFromOutside;
                originalEntity.ImpactOnLandUse = model.ImpactOnLandUse;
                originalEntity.NumberOfEmployees = model.NumberOfEmployees;
                originalEntity.PreviousSustainabilityInitiatives = model.PreviousSustainabilityInitiatives;
                originalEntity.ProduceEmissionsOrWaste = model.ProduceEmissionsOrWaste;

                var description = new StringBuilder();
                description.AppendLine($"Industry: {model.Industry}");
                description.AppendLine($"Nature of Business: {model.BusinessNature}");
                description.AppendLine($"Business Size: {model.BusinessSize}");
                description.AppendLine($"Operating Regions: {model.OperationalRegions}");  // Corrected the property name
                description.AppendLine($"Manufacturing: {model.ManufacturingInvolved}");
                description.AppendLine($"Sourcing Materials from regions: {model.SourcingFromOutside} {model.SourcingType}");
                description.AppendLine($"Direct impact on land use: {model.ImpactOnLandUse}"); // Corrected the property name
                description.AppendLine($"Employee count: {model.NumberOfEmployees}");
                description.AppendLine($"Has your business/project previously engaged in any sustainability initiatives or certifications : {model.PreviousSustainabilityInitiatives}");
                description.AppendLine($"NaturalResourceUse: {model.ProduceEmissionsOrWaste}");


                // Use the OpenAIService to initiate a chat and retrieve the response
                string responseFromAI = await _openAiService.GetQuestions(description.ToString());
                originalEntity.QuestionsText = responseFromAI;

                _context.Update(originalEntity);
                await _context.SaveChangesAsync();

                return View(model);
            }
            catch
            {
                // Log the exception if needed
                ModelState.AddModelError(string.Empty, "There was an unexpected error. Please try again.");
                Console.WriteLine("\n\n\nthere was an error");
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult SustainabilityAssessment(int id)
        {
            var projectFirm = _context.ProjectFirms.Find(id);
            if (projectFirm == null)
            {
                return NotFound();
            }
            return View(projectFirm); ;
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

        [HttpPost]
        public IActionResult HandleSustainabilityAssessment(int id, string UserAnswers)
        {
            var firm = _context.ProjectFirms.Find(id);
            if (firm == null)
            {
                return NotFound();
            }

            // Save the UserAnswer to the database or process it as required.
            firm.UserAnswers = UserAnswers;
            _context.Update(firm);
            _context.SaveChanges();

            // Redirect to a thank you page or back to the list.
            return RedirectToAction("Index");
        }

    }
}

