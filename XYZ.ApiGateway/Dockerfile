# 1. Imagen base del SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 2. Copiar csproj y restaurar dependencias
COPY XYZ.ApiGateway/XYZ.ApiGateway.csproj XYZ.ApiGateway/
RUN dotnet restore XYZ.ApiGateway/XYZ.ApiGateway.csproj

# 3. Copiar todo y compilar la app
COPY . .
WORKDIR /src/XYZ.ApiGateway
RUN dotnet publish -c Release -o /app/publish

# 4. Imagen de runtime para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# 5. Puerto expuesto (puedes cambiarlo en docker-compose)
EXPOSE 8080

# 6. Comando de ejecución
ENTRYPOINT ["dotnet", "XYZ.ApiGateway.dll"]
