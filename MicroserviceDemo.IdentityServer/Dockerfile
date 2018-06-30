FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY MicroserviceDemo.IdentityServer/MicroserviceDemo.IdentityServer.csproj MicroserviceDemo.IdentityServer/
RUN dotnet restore MicroserviceDemo.IdentityServer/MicroserviceDemo.IdentityServer.csproj
COPY . .
WORKDIR /src/MicroserviceDemo.IdentityServer
RUN dotnet build MicroserviceDemo.IdentityServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MicroserviceDemo.IdentityServer.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroserviceDemo.IdentityServer.dll"]
