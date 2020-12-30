FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./

# Copy everything else and build
COPY . ./
RUN dotnet build -c Release
RUN dotnet publish ./GameOfLifeAPI/GameOfLifeAPI.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app/
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GameOfLifeAPI.dll"]