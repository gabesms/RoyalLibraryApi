### Royal Library Web API ###
This repository contains the backend solution for a little book library database system. The solution includes a Web API built with C# using ASP.NET Core. It provides endpoints for searching and managing books based on author, ISBN, or status (own/love/want to read). The focus is on demonstrating the ability to deploy solutions in containers on Azure.

### Controller: BooksController ###
The BooksController is responsible for handling requests related to books. It provides endpoints for retrieving a list of books with pagination and adding a new book to the library.

### GET /api/books: Returns a list of books filtered with pagination. ###
Parameters:
filter: Object containing filter criteria (e.g., author, ISBN).
sorting: Object containing sorting criteria.
pagination: Object containing pagination parameters.
Response:
Returns an array of ListBookQueryResult objects representing the filtered books.

### POST /api/books: Adds a new book to the library. ###
Body:
CreateBookCommand: Object containing information about the book to be added.
Response:
Returns the result of the book addition operation.

### Class: BookHandler ###
The BookHandler class is responsible for handling the business logic related to book operations, such as adding a new book to the library.
Handle(CreateBookCommand cmd): Handles the addition of a new book.
Parameters:
cmd: Command object containing information about the book.
Returns:
Returns an ICommandResult object representing the result of the operation.

### Class: BookRepository ###
The BookRepository class is responsible for interacting with the database to retrieve and add books.
Get(BookFilter filter, string orderBy, int top, int skip, bool allRegisters, out int total): Retrieves a list of books based on filter criteria with pagination.
Add(Book model): Adds a new book to the database.

### Class: Bootstrapper ###
The Bootstrapper class contains configuration for dependency injection and setup for the ASP.NET Core application.
DependencyInjectionSetup(IServiceCollection services, IConfiguration configuration): 
Configures dependency injection for services and database context.

### Dependencies ###
The solution uses Dapper as the ORM (Object-Relational Mapping) for interacting with the database.

### Setup ###
To run the application locally, follow these steps:

Clone the repository.
Set up the database connection string in appsettings.json.
Build and run the application using Visual Studio or the .NET CLI.
Deployment
The solution can be deployed to Azure using containers. Dockerfiles and Kubernetes configurations are provided for containerization and orchestration.
