using Microsoft.EntityFrameworkCore;
using MiniApiThree.Data;
using MiniApiThree.Models;
using MiniApiThree.Models.DTOs;
using System.Net;

namespace MiniApiThree.Handlers
{
    public class WebLinkHandler
    {
        public static IResult AddLink(ApplicationContext context, int personId, int interestId, InterestLinkDto inputLink)
        {
            // Adds a link to a person and an interest. First gets the correct person and interest, then creates a new InterestLink object.
            // The person and interest is added to the InterestLink, and is then stored in the database.
            Person? person = context.People
                .Where(p => p.Id == personId)
                .Include(p => p.InterestLinks)
                .SingleOrDefault();

            Interest? interest = context.Interests
                .Where(i => i.Id == interestId)
                .Include(i => i.InterestLinks)
                .SingleOrDefault();

            InterestLink? link = new InterestLink()
            {
                Link = inputLink.Link,
                Person = person,
                Interest = interest
            };

            try
            {
                context.InterestLinks.Add(link);
            }
            catch (Exception e)
            {
                return Results.NotFound($"Failed to add link with error message: {e}");
            }

            context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
