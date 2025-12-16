# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY BioTech-Backend.sln .

# Copy all project files
COPY HealthService.Application/*.csproj ./HealthService.Application/
COPY HealthService.Domain/*.csproj ./HealthService.Domain/
COPY HealthService.Infrastructure/*.csproj ./HealthService.Infrastructure/
COPY HealthService.Presentation/*.csproj ./HealthService.Presentation/
COPY Shared.Infrastructure/*.csproj ./Shared.Infrastructure/

# Restore dependencies
RUN dotnet restore HealthService.Presentation/HealthService.Presentation.csproj

# Copy all source code
COPY . .

# Build and publish
WORKDIR /src/HealthService.Presentation
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "HealthService.Presentation.dll"]
