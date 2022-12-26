#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToolBoxDeveloper.DomainContext.MVC/ToolBoxDeveloper.DomainContext.MVC.csproj", "ToolBoxDeveloper.DomainContext.MVC/"]
COPY ["ToolBoxDeveloper.DomainContext.Domain/ToolBoxDeveloper.DomainContext.Domain.csproj", "ToolBoxDeveloper.DomainContext.Domain/"]
COPY ["ToolBoxDeveloper.DomainContext.IoC/ToolBoxDeveloper.DomainContext.IoC.csproj", "ToolBoxDeveloper.DomainContext.IoC/"]
COPY ["ToolBoxDeveloper.DomainContext.Infra/ToolBoxDeveloper.DomainContext.Infra.csproj", "ToolBoxDeveloper.DomainContext.Infra/"]
COPY ["ToolBoxDeveloper.DomainContext.Services/ToolBoxDeveloper.DomainContext.Services.csproj", "ToolBoxDeveloper.DomainContext.Services/"]
RUN dotnet restore "ToolBoxDeveloper.DomainContext.MVC/ToolBoxDeveloper.DomainContext.MVC.csproj"
COPY . .

WORKDIR "/src/ToolBoxDeveloper.DomainContext.MVC"
RUN dotnet build "ToolBoxDeveloper.DomainContext.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToolBoxDeveloper.DomainContext.MVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToolBoxDeveloper.DomainContext.MVC.dll"]