# ZipHub

## Version Control System (VCS)

A version control system (VCS) implemented in C# using Entity Framework Core. The system supports users, repositories, branches, versions (commits), and merges.

## Why "ZipHub"?

A zipper is a perfect metaphor for a version control system (VCS). Just like a zipper connects two sides into a unified line, ZipHub merges code changes into a cohesive whole. It also allows you to "unzip," revisiting previous versions when needed. 

ZipHub represents the seamless merging of individual contributions, offering flexibility, control, and the ability to track and manage your project's evolution.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Installation](#installation)
- [Database Schema](#database-schema)
- [Prerequisites](#prerequisites)
## Features

- **Create and manage repositories**: Set up and organize your project codebases.
- **Create branches from repositories**: Branch off to work on features or bug fixes independently.
- **Create versions (commits) within branches**: Track changes with versioned commits.
- **Merge branches**: Combine code from different branches, resolving conflicts if necessary.
- **Track user activities**: Monitor who is working on what and when.
- **Support for multiple users**: Allow different developers to manage their own repositories and branches.

## Technologies

- **C#**: Core language for the project.
- **ASP.NET Core**: Web API and server-side logic.
- **Entity Framework Core**: For interacting with the database.
- **SQL Server**: Relational database management system.

## Architecture
ZipHub follows a modular architecture, dividing the project into separate layers for clarity, maintainability, and scalability:

1. **Web API Layer**: Exposes endpoints to interact with repositories, branches, and commits.
2. **Service Layer**: Contains the business logic for creating and managing repositories, branches, and commits.
3. **Data Access Layer**: Interacts with the database using Entity Framework Core for CRUD operations.
4. **Database**: Uses SQL Server for storing repositories, branches, commits, and users.
5. **Dependency Injection**: The system uses Dependency Injection to ensure loose coupling between the layers and components.

This modular approach makes the system easy to extend and maintain.
## Installation
1. Clone this repository:
   ```bash
   git clone https://github.com/RGvirer/EF-API.git
2. Open the project in Visual Studio (or any C# IDE).
3. Restore the NuGet packages:
   ```bash
   dotnet restore
4. Apply database migrations to set up the database schema:
   ```bash
   dotnet ef database update
5. Run the project:
   ```bash
   dotnet run
6. The API should now be available at http://localhost:5000.

## Database Schema
The database schema consists of the following key tables:

- **Repositories**: Stores information about each repository (e.g., repository name, creation date).
- **Branches**: Stores information about branches within each repository (e.g., branch name, creation date, associated repository).
- **Commits**: Stores commit information, including changes made, the associated branch, and the user who made the commit.
- **Users**: Stores user data for authentication and activity tracking (e.g., username, email).
- **Merges**: Stores information about branch merges (e.g., source branch, target branch, merge date, user who performed the merge).
Each repository can have multiple branches, and each branch can have multiple commits. Commits are linked to both users (for activity tracking) and branches (to track the evolution of code).

![0002](https://github.com/user-attachments/assets/78d0a5c3-a193-4788-a618-21ee6647ac90)

## Prerequisites

- .NET SDK 8.0 or later
- SQL Server or any compatible SQL database
- Visual Studio or any C# IDE
