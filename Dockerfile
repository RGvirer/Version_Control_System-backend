# שלב 1: בסיס - שימוש בתמונת Docker של ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# שלב 2: Build - שימוש בתמונת Docker של .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VersionMmanagementSystem.csproj", "./"]
RUN dotnet restore "./VersionMmanagementSystem.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet publish "./VersionMmanagementSystem.csproj" -c Release -o /app/publish

# שלב 3: Final - שימוש בתמונת Runtime להרצת האפליקציה
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VersionMmanagementSystem.dll"]
