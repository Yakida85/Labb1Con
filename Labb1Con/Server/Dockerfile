#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Labb1Con/Server/Labb1Con.Server.csproj", "Labb1Con/Server/"]
COPY ["Labb1Con/Client/Labb1Con.Client.csproj", "Labb1Con/Client/"]
COPY ["Labb1Con/Shared/Labb1Con.Shared.csproj", "Labb1Con/Shared/"]
RUN dotnet restore "Labb1Con/Server/Labb1Con.Server.csproj"
COPY . .
WORKDIR "/src/Labb1Con/Server"
RUN dotnet build "Labb1Con.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Labb1Con.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Labb1Con.Server.dll"]