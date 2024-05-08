FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ibnt.Server.csproj", "./"]
RUN dotnet restore "Ibnt.Server.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Ibnt.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ibnt.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ibnt.Server.dll"]
