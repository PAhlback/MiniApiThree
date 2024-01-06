namespace MiniApiThree.Models.ErrorModels
{
    public class PostNewInterestError
    {
        public string ErrorMessage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public PostNewInterestError()
        {
            ErrorMessage = "Invalid input - all information must be submitted. Ensure json is in the following format:";
            Title = string.Empty; 
            Description = string.Empty;
        }
    }
}
