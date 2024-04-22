# HackerNewsAPI - API Integration Project

## Description
This ASP.NET Core project retrieves data from the Hacker News API. It enables fetching and displaying the top `n` best stories based on their scores.

Current implementation use simple inMemory caching and it is very raw implementation - lack of dev/prod codnfiguration file, lack of buisness class login for operations etc, but it meets basic requirements in given addingment.

## Requirements

* .NET 8.0 SDK
* Visual Studio 2022 or newer / Visual Studio Code
* Internet access for API calls to Hacker News

## How to Run

1. **Clone the repository**
    git clone https://github.com/JaroslawGosztyla/HackeNewsAPI.git
2. Navigate to the project directory
3. Restore the project dependencies
    dotnet restore 
4. Build the project
    dotnet build
5. Run the project
    dotnet run - This will start the application on a local server (typically https://localhost:5001).
6. Access the application
    Open a web browser and go to https://localhost:5001/swagger to view and interact with the Swagger UI, which provides a visual interface for API interaction.

## Performance Enhancements and possible project Enhancements

