# Exercise Application Services
This will serve as the backend for Exercise Application
The backend process the request of the angular app to fetch and sava data into the database.

### HttpGet
```
curl http://localhost:8080/set_items | jq
```
### HttpPost
```
curl -X POST -H "Content-Type: application/json" -d @payloads/setItem.json http://localhost:8080/set_items | jq
```
### Add SQLServer Dependencies for EntityFramework
```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
### Add the entity Framework Design Package 
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```
### Add the Dotnet EF Tool
```
dotnet tool install --global dotnet-ef
```