using Microsoft.EntityFrameworkCore;
using MiniApiThree.Data;
using MiniApiThree.Models;
using MiniApiThree.Models.ViewModels;
using System.Net;

namespace MiniApiThree.Handlers
{
    public class InterestHandler
    {
        public static IResult PostInterest(ApplicationContext context, Interest interest)
        {
            context.Interests.Add(interest);
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult GetAllInterests(ApplicationContext context)
        {
            List<Interest> interests = context.Interests
                .Include(i => i.InterestLinks)
                .ToList();

            List<InterestViewModelWithLink> listOfInterests = new List<InterestViewModelWithLink>();

            foreach(Interest interest in interests) 
            {
                InterestViewModelWithLink newModel = new InterestViewModelWithLink()
                {
                    Title = interest.Title,
                    Description = interest.Description,
                    Links = interest.InterestLinks
                        .Select(i => new InterestLinkViewModel()
                        {
                            Link = i.Link
                        })
                        .ToList()
                };
                listOfInterests.Add(newModel);
            }

            return Results.Json(listOfInterests);
        }

        public static IResult GetOneInterest(ApplicationContext context, int id)
        {
            InterestViewModelWithLink? newModel = context.Interests
                .Where(i => i.Id == id)
                .Include(i => i.InterestLinks)
                .Select(i => new InterestViewModelWithLink()
                {
                    Title = i.Title,
                    Description = i.Description,
                    Links = i.InterestLinks
                        .Select(i => new InterestLinkViewModel()
                        {
                            Link = i.Link
                        })
                        .ToList()
                })
                .SingleOrDefault();
            
            return Results.Json(newModel);
        }
    }
}
