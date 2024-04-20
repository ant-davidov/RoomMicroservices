FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5035

ENV ASPNETCORE_URLS=http://+:5035

ENV RABBITMQ_HOSTNAME=localhost \
    RABBITMQ_VIRTUAL_HOST=/ \
    RABBITMQ_USERNAME=guest \
    RABBITMQ_PASSWORD=guest

ENV DockerConnectionRoomDb=Host=localhost; Port=5434; UserId=myuser; Password=mysecretpassword; Database=roomsDb;

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/RoomMicroservices
COPY ["RoomMicroservices.API.csproj", "./"]
RUN dotnet restore "RoomMicroservices.API.csproj"
COPY . .
COPY ["../Common/Common.csproj", "Common/"]

WORKDIR "/src"
RUN dotnet build "RoomMicroservices/RoomMicroservices.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoomMicroservices/RoomMicroservices.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomMicroservices.API.dll"]
