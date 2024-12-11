# Use the official ASP.NET image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore any dependencies (via dotnet restore)
COPY Accessories/Accessories.csproj Accessories/
COPY DAL/DAL.csproj DAL/
COPY DataTransferObjects/DataTransferObjects.csproj DataTransferObjects/
COPY VersionMmanagementSystem/VersionMmanagementSystem.csproj VersionMmanagementSystem/

RUN dotnet restore "VersionMmanagementSystem/VersionMmanagementSystem.csproj"

# Copy the rest of the code
COPY . .

# Publish the application
RUN dotnet publish "VersionMmanagementSystem/VersionMmanagementSystem.csproj" -c Release -o /app/publish

# Set the base image again and copy the built files
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VersionMmanagementSystem.dll"]