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
            // Saves a new interest to the database. Should implement some checks here, since one interest can exist multiple times.
            context.Interests.Add(interest);
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult GetAllInterests(ApplicationContext context)
        {
            // Returns a list of all interests. First gets all interests, then converts them to interest view models with links
            // in the foreach loop.
            // There are two view models for interests - one with links, and one without.
            // Using the foreach loop was an easy way to make sure the links were added correctly. Could most likely
            // be done only using linq and .Selects instead.
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
            // Gets a single interest with links using the id passed in as a parameter.
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
