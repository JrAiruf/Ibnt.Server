FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["App.Domain/App.Domain.csproj", "App.Domain/"]
COPY ["App.Application/App.Application.csproj", "App.Application/"]
COPY ["App.Infra/App.Infra.csproj", "App.Infra/"]
COPY ["App.Tests/App.Tests.csproj", "App.Tests/"]
COPY ["Ibnt.Server/Ibnt.Server.csproj", "Ibnt.Server/"]
RUN dotnet restore "Ibnt.Server/Ibnt.Server.csproj"
COPY . .
RUN dotnet test "/src/App.Tests"
WORKDIR "/src/Ibnt.Server"
RUN dotnet build "Ibnt.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ibnt.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ibnt.Server.dll"]