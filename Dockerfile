# Stage Restore/Build .NET Project
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY ./*.sln ./

# Copy Main Source
COPY EventHorizon.Platform.Docs/EventHorizon.Platform.Docs.csproj ./EventHorizon.Platform.Docs/EventHorizon.Platform.Docs.csproj
COPY EventHorizon.Platform.Docs.Server/EventHorizon.Platform.Docs.Server.csproj ./EventHorizon.Platform.Docs.Server/EventHorizon.Platform.Docs.Server.csproj
COPY Static.PreRenderer/Static.PreRenderer.csproj ./Static.PreRenderer/Static.PreRenderer.csproj

# Restore Packages
RUN dotnet restore

COPY . .

# Build from Source
RUN dotnet build -c Release --no-restore

## Single folder publish of whole solution
RUN dotnet publish --output /app/ --configuration Release --no-restore --no-build ./EventHorizon.Platform.Docs.Server

# Stage Runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "EventHorizon.Platform.Docs.Server.dll"]
