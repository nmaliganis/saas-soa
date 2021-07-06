FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

WORKDIR /qa
COPY . .

WORKDIR "/qa/soa.qa.api"
RUN dotnet restore "soa.qa.api.csproj"
RUN dotnet build "soa.qa.api.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/qa/soa.api"
RUN dotnet publish "soa.qa.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "soa.qa.api", "--server.urls", "http://0.0.0.0:9200"]