using MiniApiThree.Models.DTOs;

namespace MiniApiThree.Models.ErrorModels
{
    public class PostNewInterestErrorInterestExists
    {
        public string ErrorMessage { get; set; }

        public PostNewInterestErrorInterestExists(InterestDto interest)
        {
            ErrorMessage = $"Interest with title {interest.Title} already exists in database";
        }
    }
}
