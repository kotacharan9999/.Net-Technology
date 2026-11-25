PRACTICAL 11 - SMART CAMPUS SERVICE PORTAL
==========================================
Technologies: ASP.NET Core MVC (.NET 10), Entity Framework Core 10, SQL Server LocalDB, REST API, custom middleware.

Features:
- Dashboard with total, pending, in-progress and resolved counts.
- Create, view, edit, delete and search campus service requests.
- Change request status from the dashboard.
- SQL Server LocalDB persistence using Entity Framework Core.
- REST API: GET, GET by ID, POST, PUT and DELETE.
- Request logging middleware.
- Browser auto-launch configuration.

RUN:
1. Extract ZIP.
2. Open terminal inside the Practical11 folder.
3. Run:
   dotnet restore
   dotnet build
   dotnet run
4. Browser address: https://localhost:7011

DATABASE:
Uses SQL Server LocalDB:
Server=(localdb)\MSSQLLocalDB;Database=SmartCampusDB;Trusted_Connection=True
Database and table are created automatically on first run using EnsureCreated().
SQL Server LocalDB must be installed. If missing, install SQL Server Express LocalDB.

If HTTPS certificate warning appears:
dotnet dev-certs https --trust

API ENDPOINTS:
GET     /api/servicerequests
GET     /api/servicerequests/{id}
POST    /api/servicerequests
PUT     /api/servicerequests/{id}
DELETE  /api/servicerequests/{id}

Example POST/PUT JSON:
{
  "studentName": "Aarav Patel",
  "email": "aarav@example.com",
  "department": "Computer Science",
  "category": "IT Support",
  "title": "Wi-Fi connection issue",
  "description": "Unable to connect to the campus Wi-Fi in the library.",
  "priority": "High",
  "status": "Pending"
}

Note: Data is stored in SQL Server LocalDB and remains after app restarts.
EnsureCreated is used for this practical starter. If you change the model schema later,
delete SmartCampusDB in SQL Server Object Explorer before restarting, or use migrations.
