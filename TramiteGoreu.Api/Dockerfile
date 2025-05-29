#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TramiteGoreu.Api/TramiteGoreu.Api.csproj", "TramiteGoreu.Api/"]
COPY ["TramiteGoreu.Dto/TramiteGoreu.Dto.csproj", "TramiteGoreu.Dto/"]
COPY ["TramiteGoreu.Persistence/TramiteGoreu.Persistence.csproj", "TramiteGoreu.Persistence/"]
COPY ["TramiteGoreu.Entities/TramiteGoreu.Entities.csproj", "TramiteGoreu.Entities/"]
COPY ["TramiteGoreu.Repositories/TramiteGoreu.Repositories.csproj", "TramiteGoreu.Repositories/"]
COPY ["TramiteGoreu.Services/TramiteGoreu.Services.csproj", "TramiteGoreu.Services/"]
RUN dotnet restore "TramiteGoreu.Api/TramiteGoreu.Api.csproj"
COPY . .
WORKDIR "/src/TramiteGoreu.Api"
RUN dotnet build "TramiteGoreu.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TramiteGoreu.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TramiteGoreu.Api.dll"]