using Microsoft.EntityFrameworkCore;
using MiniApiThree.Data;
using MiniApiThree.Handlers;

namespace MiniApiThree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            var app = builder.Build();

            app.MapGet("/", () => "Miniprojekt API");

            // People
            app.MapGet("/people", PersonHandler.GetAllPeople);
            app.MapPost("/people", PersonHandler.PostPerson);
            app.MapGet("/people/{personId}", PersonHandler.GetOnePerson);
            app.MapPost("/people/{personId}/Interests/{interestId}", PersonHandler.ConnectPersonAndInterest);
            app.MapPost("/people/{personId}/Interests/{interestId}/links", WebLinkHandler.AddLink);

            // Interests
            app.MapGet("/interests", InterestHandler.GetAllInterests);
            app.MapGet("/interests/{id}", InterestHandler.GetOneInterest);
            app.MapPost("/interests", InterestHandler.PostInterest);

            // Search function
            app.MapGet("/search", SearchHandler.SearchInformation);
            app.MapPost("/search/people", SearchHandler.SearchForPerson);
            app.MapPost("/search/interests", SearchHandler.SearchForInterest);

            app.Run();
        }
    }
}
