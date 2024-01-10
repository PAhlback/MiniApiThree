# MiniApiThree

School assignment to create a minimal API which use the get and post http verbs to store people, interests and web links in a database.
Entity Framework Core is used to interact with the SQL Database. 

## API Calls PERSON

People have the following HTTP request methods:

### GET all people

Returns all people as PeopleViewModels. This shows first name, last name and phone number.  
http://localhost:xxxx/people

### GET single person

Returns a single person as a PersonViewModel. This shows first name, last name, phone number, lists all interests, and lists all interest links associated with the person.  
http://localhost:xxxx/people/1

### POST person

Using a JSON body, creates a new person in the database. Requires the JSON to contain "firstName", "lastName", and "phoneNo".  
http://localhost:xxxx/people

### POST to connect person and interest

Using the personId and interestId sent via the address bar, links a person and an interest. Does not take a JSON body.  
http://localhost:xxxx/people/2/interests/1

## API Calls INTEREST

Interests have the following HTTP request methods:

### GET all interests

Returns all interests as InterestViewModels. This model is in the folder Models/ViewModels/PersonViewModels. It does not contain any links.  
http://localhost:xxxx/interests

### GET single interest

Returns a single interest as a InterestViewModelWithLinks.  
http://localhost:xxxx/interests/1

### POST interest

Using JSON body, creates a new interest in the database. Requires the JSON to contain "title" and "description".  
http://localhost:xxxx/interests

## API Calls LINKS

Contains only one method - AddLink - which adds a link to an interest and connects it to a person.  
Gets a personId and an interestId via parameters sent in the address bar, and an InterestLinkDto containing a variable named "link", which takes a string.  
http://localhost:xxxx/people/2/interests/1/links

## API Calls SEARCH

The root of search (http://localhost:xxxx/search) contains information on how to use the search function. The user can search either on search/people to search 
for a first name, or search/interests to search for an interest title. Search by POSTing the search query as JSON with the name "searchQuery".  
http://localhost:xxxx/search  
http://localhost:xxxx/search/interests
http://localhost:xxxx/search/people

# ER Diagram

![ER diagram](~/Images/ER-diagram.png)