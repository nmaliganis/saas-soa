FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /src
COPY . .

WORKDIR "/src/soa.api"
RUN dotnet restore "soa.api.csproj"
RUN dotnet build "soa.api.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/soa.api"
RUN dotnet publish "soa.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "soa.api", "--server.urls", "http://0.0.0.0:6200"]