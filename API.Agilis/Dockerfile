#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["API.Agilis/API.Agilis.csproj", "API.Agilis/"]
COPY ["Service.Agilis/Service.Agilis.csproj", "Service.Agilis/"]
COPY ["Domain.Agilis/Domain.Agilis.csproj", "Domain.Agilis/"]
COPY ["Repository.Agilis/Repository.Agilis.csproj", "Repository.Agilis/"]
RUN dotnet restore "API.Agilis/API.Agilis.csproj"
COPY . .
WORKDIR "/src/API.Agilis"
RUN dotnet build "API.Agilis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.Agilis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Agilis.dll"]