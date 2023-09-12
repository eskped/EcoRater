using EcoRater.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EcoRater.Interfaces;
using System.Text;
using EcoRater.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoRater.Controllers
{
    public class SustainabilityController : Controller
    {
        private readonly IOpenAIService _openAiService;
        private readonly ApplicationDbContext _context;

        public SustainabilityController(IOpenAIService openAiService, ApplicationDbContext context)
        {
            _openAiService = openAiService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Assessment()
        {
            return View(new SustainabilityAssessment());
        }


        [HttpPost]
        public async Task<IActionResult> Assessment(SustainabilityAssessment model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            try
            {
                model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // TODO 
                // Example: Setting the ProjectFirmId (You'll have to define how to get this value)
                // model.ProjectFirmId = someMethodToDetermineProjectFirmId();

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



                Console.WriteLine("\n\n\n description" + description.ToString());

                _context.SustainabilityAssessments.Add(model);
                _context.SaveChanges();

                // Use the OpenAIService to initiate a chat and retrieve the response
                string responseFromAI = await _openAiService.GetQuestions(description.ToString());

                Console.WriteLine(responseFromAI);

                // Assuming responseFromAI is a string of questions separated by newline or some delimiter
                var questions = responseFromAI.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                
                var rating = new Rating
                {
                    QuestionText = responseFromAI,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                _context.Ratings.Add(rating);
                

                await _context.SaveChangesAsync();

                return RedirectToAction("Rating", "Sustainability");

            }
            catch
            {
                // Log the exception if needed
                ModelState.AddModelError(string.Empty, "There was an unexpected error. Please try again.");
                Console.WriteLine("\n\n\nthere was an error");
                return View(model);
            }

        }

        public IActionResult DisplayRatings()
        {
            var questions = _context.Ratings.ToList();
            return View(questions);
        }

        public IActionResult Rating()
        {
            var ratings = _context.Ratings.ToList();
            return View(ratings);
        }

    }
}
