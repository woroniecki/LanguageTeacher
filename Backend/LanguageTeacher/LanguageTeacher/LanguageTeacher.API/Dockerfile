# Etap bazowy (ASP.NET runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Etap budowania (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src

# Kopiowanie pliku projektu
COPY ["LanguageTeacher.API.csproj", "LanguageTeacher.API/"]
RUN dotnet restore "LanguageTeacher.API/LanguageTeacher.API.csproj"

# Kopiowanie całego kodu
WORKDIR "/src/LanguageTeacher.API"
COPY . .
RUN dotnet build "LanguageTeacher.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etap publikacji
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LanguageTeacher.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Finalny obraz
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LanguageTeacher.API.dll"]
