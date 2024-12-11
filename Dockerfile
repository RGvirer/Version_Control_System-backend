# Use the official ASP.NET image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore any dependencies (via dotnet restore)
COPY ["VersionMmanagementSystem.csproj", "./"]
RUN dotnet restore "./VersionMmanagementSystem.csproj"

# Copy the rest of the code
COPY . .

# Publish the application
WORKDIR "/src"
RUN dotnet publish "VersionMmanagementSystem.csproj" -c Release -o /app/publish

# Set the base image again and copy the built files
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VersionMmanagementSystem.dll"]
