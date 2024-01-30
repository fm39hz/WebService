FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /web-service
EXPOSE 80
RUN apk add icu-libs icu-data-en tzdata

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /service
COPY ./WebService.API/WebService.API.csproj ./
RUN dotnet restore

COPY ./WebService.API .
WORKDIR "/service/."
RUN dotnet build -c Release -o /web-service/build

FROM build AS publish
RUN dotnet publish -c Release -o /web-service/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /web-service
COPY --from=publish /web-service/publish .
ENTRYPOINT ["dotnet", "WebService.API.dll"]
