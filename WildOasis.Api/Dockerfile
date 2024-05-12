FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WildOasis.Api/WildOasis.Api.csproj", "WildOasis.Api/"]
COPY ["WildOasis.Infrastructure/WildOasis.Infrastructure.csproj", "WildOasis.Infrastructure/"]
COPY ["WildOasis.Application/WildOasis.Application.csproj", "WildOasis.Application/"]
COPY ["WildOasis.Domain/WildOasis.Domain.csproj", "WildOasis.Domain/"]
RUN dotnet restore "WildOasis.Api/WildOasis.Api.csproj"
COPY . .
WORKDIR "/src/WildOasis.Api"
RUN dotnet build "WildOasis.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WildOasis.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WildOasis.Api.dll"]
