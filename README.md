# Student Grade Tracker


### This application was developed for Web Application module, as coursework portfolio project @ WIUT by student ID: 00012938

### Student Matching with web-app theme
As the student's ID is 12938, deviding it by 20 gives 18 in remainder (12938 = 20 * 646 + 18). Number 18 theme is Student Grade Tracker

### Web application repository on github
[link to the github repository](https://github.com/wiut00012938/WAD.CW.12938.git)

### Web application dependencies
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServe
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- AutoMapper

### external Dependencies of Web application
- tailwindcss
- open avaible image urls

### How to run this App
- download the file
- open WAD.WebApplication.12938 solution
- run the ASP.NET Core Web API project
- open GradeTrackerFrontEnd folder via vs code or any other instrument with terminal
- Run the angular project
```bash
ng serve
```

### How to run this App if there are problems with the Db:
- download the file
- open WAD.WebApplication.12938 solution
- Open nuget package manager console
- run the command 
```bash
update-database
```
- if the roles(student and teacher in AspNetRoles table) are not there, type the following command in a developer powershell (inside the vs):
```bash
dotnet run seeddata
```
- run the ASP.NET Core Web API project
- open GradeTrackerFrontEnd folder via vs code or any other instrument with terminal
- Run the angular project
```bash
ng serve
```