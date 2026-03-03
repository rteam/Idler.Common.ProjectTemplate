FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "SimpleMicroService.API.dll"]
