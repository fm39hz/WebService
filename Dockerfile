FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /web-service
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS publish
WORKDIR /service
COPY ./WebService.API/WebService.API.csproj ./
RUN dotnet restore
COPY ./WebService.API .
RUN dotnet publish -c Release -o /web-service/publish /p:UseAppHost=false

FROM base AS final
RUN apk add icu-libs icu-data-en tzdata && rm -rf ./*
COPY --from=publish /web-service/publish .
ENTRYPOINT ["dotnet", "WebService.API.dll"]
