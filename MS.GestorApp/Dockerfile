#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["MS.GestorApp/MS.GestorApp.csproj", "MS.GestorApp/"]
COPY ["MS.Aplicaciones/MS.Aplicaciones.csproj", "MS.Aplicaciones/"]
COPY ["MS.Dominio/MS.Dominio.csproj", "MS.Dominio/"]
COPY ["MS.Insfraestructura.Datos/MS.Insfraestructura.Datos.csproj", "MS.Insfraestructura.Datos/"]
RUN dotnet restore "MS.GestorApp/MS.GestorApp.csproj"
COPY . .
WORKDIR "/src/MS.GestorApp"
RUN dotnet build "MS.GestorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MS.GestorApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MS.GestorApp.dll"]