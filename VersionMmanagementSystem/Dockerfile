# שלב 1: בסיס - שימוש בתמונת Docker של ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# שלב 2: Build - שימוש בתמונת Docker של .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["YourProjectName.csproj", "./"]
RUN dotnet restore "./YourProjectName.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet publish "./YourProjectName.csproj" -c Release -o /app/publish

# שלב 3: Final - שימוש בתמונת Runtime להרצת האפליקציה
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "YourProjectName.dll"]
