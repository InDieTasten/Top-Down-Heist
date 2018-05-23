FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY TopDownHeist.Server/TopDownHeist.Server.csproj TopDownHeist.Server/
RUN dotnet restore TopDownHeist.Server/TopDownHeist.Server.csproj
COPY . .
WORKDIR /src/TopDownHeist.Server
RUN dotnet build TopDownHeist.Server.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TopDownHeist.Server.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TopDownHeist.Server.dll"]
