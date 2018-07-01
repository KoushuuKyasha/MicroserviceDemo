FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
ENV NODE_VERSION 9.11.2
ENV NODE_DOWNLOAD_SHA bbb46f86c64abe96ee98faa733424fc76f20a38d12f59bdcd60057efa5f1ce89
RUN curl -SL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.gz" --output nodejs.tar.gz \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs
WORKDIR /src
COPY MicroserviceDemo.SpaClient.csproj MicroserviceDemo.SpaClient/
RUN dotnet restore MicroserviceDemo.SpaClient/MicroserviceDemo.SpaClient.csproj
COPY . /src/MicroserviceDemo.SpaClient
WORKDIR /src/MicroserviceDemo.SpaClient
RUN dotnet build MicroserviceDemo.SpaClient.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MicroserviceDemo.SpaClient.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroserviceDemo.SpaClient.dll"]
