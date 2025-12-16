# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY BioTech-Backend.sln .

# Copy all project files
COPY HerdService.Application/*.csproj ./HerdService.Application/
COPY HerdService.Domain/*.csproj ./HerdService.Domain/
COPY HerdService.Infrastructure/*.csproj ./HerdService.Infrastructure/
COPY HerdService.Presentation/*.csproj ./HerdService.Presentation/
COPY Shared.Infrastructure/*.csproj ./Shared.Infrastructure/

# Restore dependencies
RUN dotnet restore HerdService.Presentation/HerdService.Presentation.csproj

# Copy all source code
COPY . .

# Build and publish
WORKDIR /src/HerdService.Presentation
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "HerdService.Presentation.dll"]
