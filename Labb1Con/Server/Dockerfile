#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/Labb1Con.Server.csproj", "Server/"]
COPY ["Client/Labb1Con.Client.csproj", "Client/"]
COPY ["Shared/Labb1Con.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/Labb1Con.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Labb1Con.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Labb1Con.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Labb1Con.Server.dll"]