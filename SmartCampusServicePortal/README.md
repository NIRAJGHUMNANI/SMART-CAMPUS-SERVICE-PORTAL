# Smart Campus Service Portal (Simple Practical)

A small ASP.NET Core MVC project demonstrating **MVC + database + REST API**. Built for Visual Studio 2022 and newer Visual Studio releases that support the .NET 8 SDK.

## Features
- Dashboard with total, pending, and completed request counts
- Create, list, update status, and delete campus service requests
- SQLite database created automatically on first run (`campus.db`)
- REST API returning/creating requests as JSON
- Seed data added automatically when the database is empty

## Requirements
- Visual Studio 2022 (17.8 or later recommended) or a newer compatible Visual Studio version
- **ASP.NET and web development** workload
- .NET 8 SDK
- Internet connection on first build to restore the SQLite NuGet package

## Run in Visual Studio
1. Extract the ZIP file to a normal folder.
2. Open `SmartCampusServicePortal.sln` in Visual Studio.
3. If prompted, allow NuGet packages to restore.
4. Set `SmartCampusServicePortal` as the startup project if needed.
5. Press **F5** (or click the green Run button).
6. The browser opens the dashboard. No separate database setup is required.

The project uses `net8.0` for compatibility with Visual Studio 2022 and later versions that support .NET 8. Visual Studio 2026 should be used with the .NET 8 SDK installed.

## API endpoints
- `GET /api/requests` — list all requests as JSON
- `GET /api/requests/1` — get a request by ID
- `POST /api/requests` — create a request using JSON

Example POST body:
```json
{
  "studentName": "Soham Sakhrani",
  "category": "IT Support",
  "description": "Unable to connect to campus Wi-Fi"
}
```

Use the browser for GET endpoints. For POST, use Visual Studio's HTTP file support, Postman, or curl. Example curl:
```bash
curl -X POST https://localhost:7148/api/requests -H "Content-Type: application/json" -d "{\"studentName\":\"Soham Sakhrani\",\"category\":\"IT Support\",\"description\":\"Wi-Fi issue\"}" -k
```

## Where the practical concepts are used
- **Model:** `Models/ServiceRequest.cs`
- **Database / EF Core:** `Data/CampusDbContext.cs`
- **MVC controllers:** `Controllers/HomeController.cs`, `Controllers/RequestsController.cs`
- **Views:** `Views/Home/Index.cshtml`, `Views/Requests/`
- **REST API:** `Controllers/ServiceRequestsApiController.cs`
- **Database file:** `campus.db` (created in the app's working directory)

This is an educational demonstration, not a production portal: authentication, role-based access, and advanced validation are intentionally omitted to keep the practical simple.
