#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ClimFit.Api/ClimFit.Api.csproj", "ClimFit.Api/"]
COPY ["ClimFit.Infrastructure/ClimFit.Infrastructure.csproj", "ClimFit.Infrastructure/"]
COPY ["ClimFit.Abstractions/ClimFit.Abstractions.csproj", "ClimFit.Abstractions/"]
COPY ["ClimFit.Common/ClimFit.Common.csproj", "ClimFit.Common/"]
COPY ["ClimFit.Business/ClimFit.Business.csproj", "ClimFit.Business/"]
COPY ["ClimFit.Data/ClimFit.Data.csproj", "ClimFit.Data/"]
COPY ["ClimFit.DataAccess/ClimFit.DataAccess.csproj", "ClimFit.DataAccess/"]
RUN dotnet restore "./ClimFit.Api/ClimFit.Api.csproj"
COPY . .
WORKDIR "/src/ClimFit.Api"
RUN dotnet build "./ClimFit.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ClimFit.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClimFit.Api.dll"]

