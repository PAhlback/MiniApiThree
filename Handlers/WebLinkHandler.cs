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
                return Results.NotFound($"Failed at adding link with error message: {e}");
            }

            context.SaveChanges();

            //try
            //{
            //    person.InterestLinks.Add(link);
            //    interest.InterestLinks.Add(link);
            //}
            //catch (Exception e)
            //{
            //    return Results.NotFound($"Failed at adding link with error message: {e}");
            //}
            //context.SaveChanges();

            return Results.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
