using System;
using OpenAI;
using OpenAI_API;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using OpenAI.ObjectModels.RequestModels;
using EcoRater.Interfaces;

namespace EcoRater.Services
{

    public class OpenAIService : IOpenAIService
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public OpenAIService(IConfiguration configuration)
        {
            _configuration = configuration;
            try
            {
                _apiKey = configuration["OpenAIApiKey"];
                if (string.IsNullOrEmpty(_apiKey))
                {
                    throw new Exception("API Key not found in configuration.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // log the exception as necessary
            }
        }

        public async Task<String> GetQuestions(string userInput)
        {
            // var apiKey = Configuration["OpenAIApiKey
            // var apiKey = _configuration["OpenAIServiceOptions:ApiKey"];
            // var apiKey = _configuration["OpenAIApiKey"];

            Console.WriteLine("\n\n\n _apiKey", _apiKey);
            OpenAIAPI api = new (_apiKey);

            // Create a new chat conversation
            var chat = api.Chat.CreateConversation();

            // Provide instruction to the chatbot
            chat.AppendSystemMessage("You are EcoRater, an AI-powered sustainability assessment tool designed to provide customized questions about a business or project's sustainability. Based on the general answers provided by the user about their venture, craft specific questions that will delve deeper into the details of their sustainability practices and alignment with Environmental, Social, and Economic pillars. Your questions should be tailored to the unique characteristics and operations of the business or project in question.\n");

         
            chat.AppendUserInput(userInput);
            string response = await chat.GetResponseFromChatbotAsync();
            // Console.WriteLine("\n\n\n" + response);

            return response;     
        }

        public async Task<String> GetRating(string userAnswers)
        {

            var apiKey = _configuration["OpenAIServiceOptions:ApiKey"];
            OpenAIAPI api = new(apiKey);

            // Create a new chat conversation
            var chat = api.Chat.CreateConversation();
            // Provide instruction to the chatbot
            chat.AppendSystemMessage("\"app_description\": \"Unveiling EcoRater: Northern Europe's premier tool for intuitive sustainability assessment. Designed for individuals, entrepreneurs, and businesses alike, EcoRater serves as a preliminary lens, offering a snapshot of a project or firm's alignment with the three pillars of sustainability: Environmental, Social, and Economic. Harnessing the power of AI technology, users not only receive a comprehensive rating but also actionable feedback to enhance their sustainability footprint across all three dimensions.\",\n\"key_features\": [\n      \"Triple-Bottom-Line Focus: Delve into specific insights on how your project or firm measures up in Environmental, Social, and Economic aspects.\",\n      \"Instant Ratings with Feedback: Beyond a simple rating, EcoRater empowers users with AI-driven recommendations to bolster their sustainability profile.\",\n      \"Accessible & User-Centric: EcoRater is molded for all, whether you're well-versed in sustainability or just starting out on your green journey.\"\n    ]\n\"vision\": \"In today's evolving landscape, sustainability is multifaceted. With EcoRater, our ambition is to simplify this complexity, offering Northern Europe a dynamic tool that\nnot only rates but educates, guiding users towards a more sustainable future in business and beyond.\",\n  \"instructions\": \"Based on the provided information and the structured Q&A string, please generate, in this order, separated with “;”  an overall rating, Environmental rating, an Social rating, Economic rating, overall feedback, and future recommendations. The rating should be between 0-10.“");


            chat.AppendUserInput(userAnswers);
            string response = await chat.GetResponseFromChatbotAsync();
            // Console.WriteLine("\n\n\n" + response);

            return response;
        }
    }
}