#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 7777/udp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebSocket/WebSocket.csproj", "WebSocket/"]
RUN dotnet restore "WebSocket/WebSocket.csproj"
COPY . .
WORKDIR "/src/WebSocket"
RUN dotnet build "WebSocket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebSocket.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebSocket.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["ProgressApi/ProgressApi.csproj", "ProgressApi/"]
#RUN dotnet restore "ProgressApi/ProgressApi.csproj"
#COPY . .
#WORKDIR "/src/ProgressApi"
#RUN dotnet build "ProgressApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ProgressApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ProgressApi.dll"]