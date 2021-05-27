# Smart-cHarger360 API App smart-charger.api Reference Apps for Software Engineering Ntua Lab

<p align="center">
<img src="../documentation/Images/Logo2.png"/>
</p>


- Technologies:
  - ASP.NET Core 3.1 Web Application

- Prerequisite:
- [ASP.NET Core SDK 3.1.407 ](https://dotnet.microsoft.com/download/dotnet/3.1)

- Build:
  - [dotnet build --configuration Release (Any Env)](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build)
  - dotnet build --runtime ubuntu.18.04-x64 (Any Env)

    All dependencies are controlled via Nuget.File (Same as Grandle Java, package.json Javascript)

- Run:
  - [dotnet run --verbosity --project ./smart-charger.cli.csproj (Any Env)](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run)

    All dependencies are controlled via Nuget.File (Same as Grandle Java, package.json Javascript)



# Back-end Components


Components project structure:

<p align="center">
<img src="../documentation/Images/be.png"/>
</p>

# Back-end Azure - Swagger OpenApi 

Live: 
- [Back-end Azure](https://sh-360-api.azurewebsites.net/swagger/index.html)
API Documentation:
<p align="center">
<img src="../documentation/Images/swagger-1.png"/>
</p>

# Back-end CICD - GitHub Actions


DevOps Build-Deployment Architecture:
<p align="center">
<img src="../documentation/Images/cicd.png"/>
</p>

DevOps GitHUb_Actions:
<p align="center">
<img src="../documentation/Images/ga.png"/>
</p>



# Back-end Features

- [DDD - Design & Architecture](https://en.wikipedia.org/wiki/Domain-driven_design)
- [ORM - Nhibernate](https://nhibernate.info/)
- [Swagger - OpenApi](https://swagger.io/specification/)
- [Azure Hosting - Dockers](https://azure.microsoft.com/en-us/services/kubernetes-service/docker/)
- [PostGIS - Support Geo-Spatial](https://postgis.net/)
- [Azure PostgreSQL](https://azure.microsoft.com/en-us/services/postgresql/)
- [Docker support - ACR Artifactory](https://azure.microsoft.com/en-us/services/container-registry/)
- [CICD-Pipelines - GitHub Actions](https://github.com/actions)
