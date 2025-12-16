# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY BioTech-Backend.sln .

# Copy all project files
COPY CommercialService.Application/*.csproj ./CommercialService.Application/
COPY CommercialService.Domain/*.csproj ./CommercialService.Domain/
COPY CommercialService.Infrastructure/*.csproj ./CommercialService.Infrastructure/
COPY CommercialService.Presentation/*.csproj ./CommercialService.Presentation/
COPY Shared.Infrastructure/*.csproj ./Shared.Infrastructure/

# Restore dependencies
RUN dotnet restore CommercialService.Presentation/CommercialService.Presentation.csproj

# Copy all source code
COPY . .

# Build and publish
WORKDIR /src/CommercialService.Presentation
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "CommercialService.Presentation.dll"]
