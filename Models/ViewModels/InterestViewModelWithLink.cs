namespace MiniApiThree.Models.ViewModels
{
    public class InterestViewModelWithLink
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<InterestLinkViewModel> Links { get; set; }
    }
}
