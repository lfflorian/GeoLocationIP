#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
COPY ["DB/GeoLite2-Country.mmdb", "db/"]
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GeoAPI.webapi/GeoAPI.webapi.csproj", "GeoAPI.webapi/"]
COPY ["GeoAPI.Entities/GeoAPI.Entities.csproj", "GeoAPI.Entities/"]
RUN dotnet restore "GeoAPI.webapi/GeoAPI.webapi.csproj"
COPY . .
WORKDIR "/src/GeoAPI.webapi"
RUN dotnet build "GeoAPI.webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeoAPI.webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeoAPI.webapi.dll"]