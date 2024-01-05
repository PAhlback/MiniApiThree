using MiniApiThree.Data;
using MiniApiThree.Models.DTOs.SearchDTOs;
using MiniApiThree.Models.ViewModels;
using MiniApiThree.Models.ViewModels.PersonViewModels;

namespace MiniApiThree.Handlers
{
    public class SearchHandler
    {
        public static string SearchInformation()
        {
            string information = "To use the search function, navigate to either \"search/people\", or \"search/interest\". " +
                "Then send (POST) your search query as JSON with a single line \"searchQuery\": \"text\". " +
                "Searching for a person searches for a first name, while " +
                "interest will search for the title of the interest";

            return information;
        }

        public static IResult SearchForPerson(ApplicationContext context, SearchDto query)
        {
            // Uses the .StartsWith() method to search for a person with a first name that starts with the search query
            // posted via json.
            List<PeopleViewModel> result = context.People
                .Where(p => p.FirstName.StartsWith(query.SearchQuery))
                .Select(p => new PeopleViewModel()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNo = p.PhoneNo
                })
                .ToList();

            if (result.Count == 0)
            {
                return Results.NotFound(new { Message = $"No person with first name that starts with {query.SearchQuery} was found" });
            }

            return Results.Json(result);
        }

        public static IResult SearchForInterest(ApplicationContext context, SearchDto query)
        {
            // Same as the SearchForPerson method above, but looks for interest title starting with the search query instead.
            List<InterestViewModel> result = context.Interests
                .Where(i => i.Title.StartsWith(query.SearchQuery))
                .Select(i => new InterestViewModel()
                {
                    Title = i.Title,
                    Description = i.Description
                })
                .ToList();

            if (result.Count == 0)
            {
                return Results.NotFound(new { Message = $"No interest with title that starts with {query.SearchQuery} was found" });
            }

            return Results.Json(result);
        }
    }
}
