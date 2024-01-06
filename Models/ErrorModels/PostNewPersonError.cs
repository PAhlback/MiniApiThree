namespace MiniApiThree.Models.ErrorModels
{
    public class PostNewPersonError
    {
        public string ErrorMessage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }

        public PostNewPersonError()
        {
            ErrorMessage = "Invalid input - all information must be submitted. Ensure json is in the following format:";
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNo = string.Empty;
        }
    }
}
