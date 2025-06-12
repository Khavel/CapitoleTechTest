FROM mcr.microsoft.com/dotnet/aspnet:6.0.12-focal-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0.404-focal-amd64 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src


COPY GtMotive.Estimate.Microservice.Host/GtMotive.Estimate.Microservice.Host.csproj GtMotive.Estimate.Microservice.Host/
COPY GtMotive.Estimate.Microservice.Api/GtMotive.Estimate.Microservice.Api.csproj GtMotive.Estimate.Microservice.Api/
COPY GtMotive.Estimate.Microservice.ApplicationCore/GtMotive.Estimate.Microservice.ApplicationCore.csproj GtMotive.Estimate.Microservice.ApplicationCore/
COPY GtMotive.Estimate.Microservice.Domain/GtMotive.Estimate.Microservice.Domain.csproj GtMotive.Estimate.Microservice.Domain/
COPY GtMotive.Estimate.Microservice.Infrastructure/GtMotive.Estimate.Microservice.Infrastructure.csproj GtMotive.Estimate.Microservice.Infrastructure/

# Feeds de Azure (comentado porque no se usan)
# ARG PersonalAccessToken
# ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED=true
# ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS="{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/gtmotive/_packaging/GtMotivePackages/nuget/v3/index.json\", \"password\":\"${PersonalAccessToken}\"}]}"

RUN dotnet restore "GtMotive.Estimate.Microservice.Host/GtMotive.Estimate.Microservice.Host.csproj"


COPY . .

WORKDIR "/src/GtMotive.Estimate.Microservice.Host"
RUN dotnet build "GtMotive.Estimate.Microservice.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "GtMotive.Estimate.Microservice.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GtMotive.Estimate.Microservice.Host.dll"]
