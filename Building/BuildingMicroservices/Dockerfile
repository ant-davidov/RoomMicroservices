FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5036

ENV ASPNETCORE_URLS=http://+:5036

ENV RABBITMQ_HOSTNAME=localhost \
    RABBITMQ_VIRTUAL_HOST=/ \
    RABBITMQ_USERNAME=guest \
    RABBITMQ_PASSWORD=guest
    
ENV DefaultConnectionBuildingDb="Host=localhost; Port=5433; User Id=myuser; Password=mysecretpassword; Database=buildingDb;"
# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Building/BuildingMicroservices/BuildingMicroservices.API.csproj", "Building/BuildingMicroservices/"]
RUN dotnet restore "Building/BuildingMicroservices/BuildingMicroservices.API.csproj"
COPY . .
WORKDIR "/src/Building/BuildingMicroservices"
RUN dotnet build "BuildingMicroservices.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BuildingMicroservices.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BuildingMicroservices.API.dll"]
