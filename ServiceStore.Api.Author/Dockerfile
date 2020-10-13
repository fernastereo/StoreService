#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ServiceStore.Api.Author/ServiceStore.Api.Author.csproj", "ServiceStore.Api.Author/"]
RUN dotnet restore "ServiceStore.Api.Author/ServiceStore.Api.Author.csproj"
COPY . .
WORKDIR "/src/ServiceStore.Api.Author"
RUN dotnet build "ServiceStore.Api.Author.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceStore.Api.Author.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceStore.Api.Author.dll"]
