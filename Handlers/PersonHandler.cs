using Microsoft.EntityFrameworkCore;
using MiniApiThree.Data;
using MiniApiThree.Models;
using MiniApiThree.Models.ViewModels;
using MiniApiThree.Models.ViewModels.PersonViewModels;
using System.Net;

namespace MiniApiThree.Handlers
{
    public class PersonHandler
    {
        public static IResult GetAllPeople(ApplicationContext context)
        {
            List<PeopleViewModel> people = context.People
                .Select(p => new PeopleViewModel()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNo = p.PhoneNo
                })
                .ToList();
            return Results.Json(people);
        }

        public static IResult PostPerson(ApplicationContext context, Person person)
        {
            context.People.Add(person);
            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult GetOnePerson(ApplicationContext context, int personId)
        {
            Person? person = context.People
                .Where(p => p.Id == personId)
                .Include(p => p.Interests)
                .Include(p => p.InterestLinks)
                .SingleOrDefault();

            OnePersonViewModel personViewModel = new OnePersonViewModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                PhoneNo = person.PhoneNo,
                Interests = person.Interests
                    .Select(i => new InterestViewModel()
                    {
                        Title = i.Title,
                        Description = i.Description
                    })
                    .ToList(),
                InterestLinks = person.InterestLinks
                    .Select(il => new InterestLinkViewModel()
                    {
                        Link = il.Link
                    })
                    .ToList()
            };

            return Results.Json(personViewModel);
        }

        public static IResult ConnectPersonAndInterest(ApplicationContext context, int personId, int interestId)
        {
            Person? person = context.People
                .Where(p => p.Id == personId)
                .Include(p => p.Interests)
                .SingleOrDefault();

            Interest? interest = context.Interests
                .Where(i => i.Id == interestId)
                .Include(p => p.People)
                .SingleOrDefault();

            try
            {
                person.Interests.Add(interest);
            }
            catch (Exception ex)
            {
                return Results.NotFound($"Failed with error message: {ex}");
            }

            context.SaveChanges();
            return Results.StatusCode((int)HttpStatusCode.Created);
        }
    }
}
