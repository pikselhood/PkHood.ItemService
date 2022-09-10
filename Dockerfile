# Base ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
LABEL org.opencontainers.image.source="https://github.com/pikselhood/PkHood.ItemService"
EXPOSE 5000

# Build layer
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . .
WORKDIR src/GameService
RUN dotnet build ItemService.csproj -c Release -o /app

# Publish dll
FROM build AS publish
RUN dotnet publish ItemService.csproj -c Release -o /app 

# Entrypoint
FROM base AS final
COPY --from=publish /app .
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "ItemService.dll", "--environment=prod"]
