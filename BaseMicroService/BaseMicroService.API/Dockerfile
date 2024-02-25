FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "BaseMicroService.API.dll"]
