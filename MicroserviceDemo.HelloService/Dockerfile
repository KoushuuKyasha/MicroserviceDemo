FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY MicroserviceDemo.HelloService.csproj MicroserviceDemo.HelloService/
RUN dotnet restore MicroserviceDemo.HelloService/MicroserviceDemo.HelloService.csproj
COPY . /src/MicroserviceDemo.HelloService
WORKDIR /src/MicroserviceDemo.HelloService
RUN dotnet build MicroserviceDemo.HelloService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MicroserviceDemo.HelloService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroserviceDemo.HelloService.dll"]
