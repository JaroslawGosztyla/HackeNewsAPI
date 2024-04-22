# HackerNewsAPI - API Integration Project

## Description
This ASP.NET Core project retrieves data from the Hacker News API. It enables fetching and displaying the top `n` best stories based on their scores.

Current implementation uses simple i nMemory caching and it is very raw implementation - lack of dev/prod configuration file, lack of buisness class login for operations etc, but it meets basic requirements in given addingment.

## Requirements

* .NET 8.0 SDK
* Visual Studio 2022 or newer / Visual Studio Code
* Internet access for API calls to Hacker News

## How to Run

1. **Clone the repository**
    git clone https://github.com/JaroslawGosztyla/HackeNewsAPI.git
2. **Navigate to the project directory**
3. **Restore the project dependencies**
    ```console
    dotnet restore
    ``` 
5. **Build the project**
   ```console
   dotnet build
   ```
6. **Run the project**
   ```console
   dotnet run
   ```
   - This will start the application on a local server (typically https://localhost:5001).
7. **Access the application**
    Open a web browser and go to https://localhost:5001/swagger to view and interact with the Swagger UI, which provides a visual interface for API interaction.

## Performance Enhancements and possible project Enhancements
1.  **Caching Mechanismst**
    In solution we have In-memory caching: Quick and suitable for single-instance deployments.  If your application scales horizontally across multiple servers, use distributed caches like Redis or Memcached. These can also handle failovers and data persistence.
    We can allign Cache invalidation strategy coresponding to API - clear rules for cache expiration and invalidation. For example, you could refresh cache entries every few minutes or based on specific triggers like updates in the data source.
2. **Rate Limiting**
    We can Implement rate limiting on the API to control the number of requests a user can make in a certain time period. This helps in managing the load and preventing abuse.
    * Client-side rate limiting: Limits at the client level to ensure no single user overloads the service.
    * Server-side rate limiting: Global limits to protect backend services including third-party APIs like Hacker News.
3. **Load Balancing**
    Use load balancers to distribute incoming API requests evenly across multiple servers. This not only optimizes resource utilization but also improves response times and avoids overloading any single server.
4. **Asynchronous Processing**
    For operations that require more processing time and involve several API calls (like fetching multiple stories), use asynchronous processing:
    * Background jobs: Processes that run in the background like fetching data from Hacker News and updating the cache periodically.
    * Webhooks: Instead of clients polling for changes, use webhooks if possible to notify about updates.
5. **API Gateway**
    Use an API gateway to manage API requests. It can handle aspects like caching responses, rate limiting, request routing, and authentication, offloading these tasks from individual services.
6. **Queue Systems**
    For handling large volumes of requests, implement queue systems. They help in managing load spikes by queuing incoming requests and processing them at a manageable rate.
7. **Monitoring and Alerts**
    Implement monitoring tools to keep track of API usage, performance metrics, and error rates. This helps in proactive management of resources and quick troubleshooting of issues.


