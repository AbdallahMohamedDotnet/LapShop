# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Install SQL Server dependencies
RUN apt-get update \
    && apt-get install -y curl apt-transport-https gnupg2 \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/debian/12/prod.list > /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y msodbcsql18 mssql-tools unixodbc-dev \
    && ACCEPT_EULA=Y apt-get install -y mssql-server \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

ENV SA_PASSWORD=Your_password123
ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Express

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LapShopv2.csproj", "."]
RUN dotnet restore "./LapShopv2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./LapShopv2.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LapShopv2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY start-with-sqlserver.sh /app/start-with-sqlserver.sh
RUN chmod +x /app/start-with-sqlserver.sh
ENTRYPOINT ["/app/start-with-sqlserver.sh"]