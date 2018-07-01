FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY MicroserviceDemo.ApiGateway.csproj MicroserviceDemo.ApiGateway/
RUN dotnet restore MicroserviceDemo.ApiGateway/MicroserviceDemo.ApiGateway.csproj
COPY . /src/MicroserviceDemo.ApiGateway
WORKDIR /src/MicroserviceDemo.ApiGateway
RUN dotnet build MicroserviceDemo.ApiGateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MicroserviceDemo.ApiGateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroserviceDemo.ApiGateway.dll"]
