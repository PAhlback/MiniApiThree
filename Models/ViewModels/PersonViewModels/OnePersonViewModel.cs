namespace MiniApiThree.Models.ViewModels.PersonViewModels
{
    public class OnePersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }

        public List<InterestViewModel> Interests { get; set; }
        public List<InterestLinkViewModel> InterestLinks { get; set; }
    }
}
