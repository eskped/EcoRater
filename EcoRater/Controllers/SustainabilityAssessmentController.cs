using System;
using System.Linq;
using System.Threading.Tasks;
using EcoRater.Models;
using Microsoft.AspNetCore.Mvc;
using Betalgo.OpenAI;
using Betalgo.OpenAI.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;

namespace EcoRater.Controllers
{
    public class SustainabilityController : Controller
    {
        private readonly IOpenAIService _openAiService;

        public SustainabilityController(IOpenAIService openAiService)
        {
            _openAiService = openAiService;
        }

        [HttpGet]
        public IActionResult Assessment()
        {
            return View(new SustainabilityAssessment());
        }

        [HttpPost]
        public async Task<IActionResult> Assessment(SustainabilityAssessment model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Sample chat with GPT model. Adjust this based on your actual needs.
                var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                    {
                        ChatMessage.FromSystem("You are a helpful assistant."),
                        // Add a question based on the model data, for example:
                        ChatMessage.FromUser($"Does the company have sustainability initiatives?")
                        // You can add more questions/messages based on the model fields
                    },
                    Model = Models.ChatGpt3_5Turbo,
                    //MaxTokens = 50 // optional
                });

                if (completionResult.Successful)
                {
                    var response = completionResult.Choices.First().Message.Content;
                    // Process the response as needed
                    // E.g., store it, display it in a view, etc.
                    return View("ResultsView", response);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "There was an error processing the request with OpenAI. Please try again.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                ModelState.AddModelError(string.Empty, "There was an unexpected error. Please try again.");
                return View(model);
            }
        }
    }
}
