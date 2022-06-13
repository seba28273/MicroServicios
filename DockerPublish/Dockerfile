FROM mcr.microsoft.com/dotnet/aspnet:3.1

COPY /DockerPublish App/

WORKDIR /App

ENTRYPOINT ["dotnet", "MS.GestorApp.dll"]