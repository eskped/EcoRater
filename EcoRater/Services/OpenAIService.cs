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

        public OpenAIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<String> GetQuestions(string userInput)
        {

            var apiKey = _configuration["OpenAIServiceOptions:ApiKey"];
            OpenAIAPI api = new OpenAIAPI(apiKey);

            // Create a new chat conversation
            var chat = api.Chat.CreateConversation();

            // Provide instruction to the chatbot
            chat.AppendSystemMessage("You are EcoRater, an AI-powered sustainability assessment tool designed to provide customized questions about a business or project's sustainability. Based on the general answers provided by the user about their venture, craft specific questions that will delve deeper into the details of their sustainability practices and alignment with Environmental, Social, and Economic pillars. Your questions should be tailored to the unique characteristics and operations of the business or project in question.\n");

         
            chat.AppendUserInput(userInput);
            string response = await chat.GetResponseFromChatbotAsync();
            Console.WriteLine("\n\n\n" + response);


            return response;
            
            
        }
    }
}