FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cars.API/Cars.API.csproj", "Cars.API/"]
COPY ["Cars.Domain/Cars.Domain.csproj", "Cars.Domain/"]
COPY ["Cars.Database/Cars.Database.csproj", "Cars.Database/"]
RUN dotnet restore "Cars.API/Cars.API.csproj"
COPY . .
WORKDIR "/src/Cars.API"
RUN dotnet build "Cars.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Cars.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cars.API.dll"]
