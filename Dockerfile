# Base stage for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore BioTech-Backend.sln

# Publish Auth Service
FROM build AS publish-auth
RUN dotnet publish "AuthService.Presentation/AuthService.Presentation.csproj" -c Release -o /app/auth

# Publish Feeding Service
FROM build AS publish-feeding
RUN dotnet publish "FeedingService.Presentation/FeedingService.Presentation.csproj" -c Release -o /app/feeding

# Publish API Gateway
FROM build AS publish-gateway
RUN dotnet publish "ApiGateWay/ApiGateWay.csproj" -c Release -o /app/gateway

# Final Stage: Auth
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS auth
WORKDIR /app
COPY --from=publish-auth /app/auth .
EXPOSE 8080
ENTRYPOINT ["dotnet", "AuthService.Presentation.dll"]

# Final Stage: Feeding
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS feeding
WORKDIR /app
COPY --from=publish-feeding /app/feeding .
EXPOSE 8080
ENTRYPOINT ["dotnet", "FeedingService.Presentation.dll"]

# Final Stage: Gateway
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS gateway
WORKDIR /app
COPY --from=publish-gateway /app/gateway .
EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiGateWay.dll"]
