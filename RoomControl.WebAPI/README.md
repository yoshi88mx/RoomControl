# Introduction 
Rooms Control is a Web API (Backend) that try to show the way I work, Im gonna listing the Technologies, tools, etc, used to build this project.

# Tools and technologies
1.	.NET 5
2.	Entityframework Core 5 (Code First)
3.	AutoMapper
4.	FluentValidation
5.	Swagger
6.	Docker
7.  Azure DevOps
8.  xUnit
9.  Moq
10. Azure Storage Blob
11. Visual Studio 2022
12. Visual Studio Code
13. SQL Server

# Build and Test
Open a window terminal and run this commands  
To test: dotnet test  
To Build: dotnet build  
To Run: dotnet run  

This is optional because the system once start, is ensure to build the database  
To Build the database: dotnet ef database update  

If you want to run using docker with your local instance of SQL Server  
To Docker: docker run --rm --name stat -it -d -p 8090:8080 -e ConnectionStrings:SQL="Server=host.docker.internal;Database=RoomsControl;User Id=YOURUSERNAMEHERE;Password=YOURPASSWORDHERE;" NAMEORHASHIMAGE  

# Setting
You need to change the connectionString's into the appsetting.json file