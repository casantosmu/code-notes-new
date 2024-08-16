# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY src/*.sln .
COPY src/CodeNotes.Web/*.csproj CodeNotes.Web/
RUN dotnet restore

COPY src/CodeNotes.Web/ CodeNotes.Web/
WORKDIR /source/CodeNotes.Web
RUN dotnet publish -c Release -o /app

# Stage 2: Create the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app .
COPY docs/ docs/

ENTRYPOINT ["dotnet", "CodeNotes.Web.dll"]