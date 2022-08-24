#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RoomControl.WebApi/RoomControl.WebApi.csproj", "RoomControl.WebApi/"]
COPY ["RoomControl.Data/RoomControl.Data.csproj", "RoomControl.Data/"]
COPY ["RoomControl.Core/RoomControl.Core.csproj", "RoomControl.Core/"]
COPY ["RoomControl.Bussines/RoomControl.Bussines.csproj", "RoomControl.Bussines/"]
COPY ["RoomControl.Shared/RoomControl.Shared.csproj", "RoomControl.Shared/"]

RUN dotnet restore "RoomControl.WebApi/RoomControl.WebApi.csproj"
COPY . .
WORKDIR "/src/RoomControl.WebApi"
RUN dotnet build "RoomControl.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoomControl.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomControl.WebApi.dll"]