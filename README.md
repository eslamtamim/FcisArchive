# Fcis Archive 
---

## Project Overview
Fcis-Archive is a web application developed to address a problem encountered at a college setting. The need was to swiftly transform questions from a PDF file, typically created by classmates, into an interactive format that resembles Telegram's channel polls. This application is designed to convert questions from a specific PDF file into a Multiple-Choice Questions (MCQ) web application within seconds.

## Problem Statement
In an academic environment, there was a requirement for an efficient way to convert questions written in a PDF format into an interactive format, similar to Telegram's channel polls. This need was the catalyst for the development of Fcis-Archive, aimed at simplifying the process of transforming PDF questions into an MCQ web application.

## Technologies Used
- C#
- .NET Core
- ASP.NET Core Razor
- Blazor
- SQL Server
- SQL
- EF Core
- ASP.NET Identity (User Management)
- Regex (Used for parsing questions from the PDF)
- Pagination
- Caching (in memory)
- Azure (App Deployment)
- Digital Ocean (Database Deployment)

## Live Preview
[Live Preview on Azure](https://fcis-archive-blazor.azurewebsites.net)

## Install and Use 
To try Fcis-Archive application locally, follow these steps:
1. Clone the repo.
2. Add `FcisArchiveBlazor/appsettings.json` 
   here is what should this file contain 
 ```
 {
  "ConnectionStrings": {
    "DefaultConnection": "[Your local database connection string]"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
3. You need the [.NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)installed 
4. Run the app Using the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).
5. everything should be clear enough to use the app, just go to `/upload` from the navigation layout on the left
6. upload any file from this [Folder](https://drive.google.com/drive/folders/1ABybBDinUSADI72-prqyBOow-JEjI_US?usp=sharing)

## Special Thanks 

All the Questions prepared in the folder above by [Amr Shoukry | LinkedIn](https://www.linkedin.com/in/amrshoukry/)

## Contributing
Contributions to this project are welcome! To contribute, follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push your changes to your fork.
5. Submit a pull request with a description of your changes.

## Contact
For inquiries or support, please contact me [Eslam.Elmetwalli.Tamim@gmail.com] or on telegram [@mimatmalxe](https://t.me/mimatmalxe)
