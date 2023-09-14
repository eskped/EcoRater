using System;
namespace EcoRater.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GetQuestions(string userInput);
        Task<string> GetRating(string v);
    }
}

