PRACTICAL 10 - STUDENT MANAGEMENT REST API
==========================================

Project: ASP.NET Core Web API (.NET 10)
Features:
- Student CRUD REST API (GET, GET by ID, POST, PUT, DELETE)
- Custom request logging middleware
- Model validation using Data Annotations
- Swagger UI for interactive API testing
- Browser automatically opens at /swagger when run with the project launch profile

HOW TO RUN
----------
1. Extract this ZIP file.
2. Open the Practical10 folder in Visual Studio 2026, or open a terminal in that folder.
3. Run:
      dotnet restore
      dotnet build
      dotnet run
4. The browser should automatically open:
      https://localhost:7003/swagger

If the browser does not open automatically, manually open:
      https://localhost:7003/swagger

If HTTPS shows a local development certificate warning, run once:
      dotnet dev-certs https --trust
Then restart the app.

API ENDPOINTS
-------------
GET     /api/students       - Get all students
GET     /api/students/{id}  - Get one student
POST    /api/students       - Add a student
PUT     /api/students/{id}  - Update a student
DELETE  /api/students/{id}  - Delete a student

SAMPLE DATA
-----------
Three sample students are loaded when the app starts. Data is stored in memory,
so changes are reset when the application restarts.

IMPORTANT
---------
Use the "Practical10" launch profile. The launchSettings.json file sets
launchBrowser=true and launchUrl=swagger. Running with "dotnet run --no-launch-profile"
will not automatically open the browser.
