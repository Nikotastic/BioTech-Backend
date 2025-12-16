# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY BioTech-Backend.sln .

# Copy all project files
COPY InventoryService.Application/*.csproj ./InventoryService.Application/
COPY InventoryService.Domain/*.csproj ./InventoryService.Domain/
COPY InventoryService.Infrastructure/*.csproj ./InventoryService.Infrastructure/
COPY InventoryService.Presentation/*.csproj ./InventoryService.Presentation/
COPY Shared.Infrastructure/*.csproj ./Shared.Infrastructure/

# Restore dependencies
RUN dotnet restore InventoryService.Presentation/InventoryService.Presentation.csproj

# Copy all source code
COPY . .

# Build and publish
WORKDIR /src/InventoryService.Presentation
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "InventoryService.Presentation.dll"]
