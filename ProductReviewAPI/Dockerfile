# Usa la imagen oficial de .NET para producción
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ProductReviewAPI/ProductReviewAPI.csproj", "ProductReviewAPI/"]
RUN dotnet restore "ProductReviewAPI/ProductReviewAPI.csproj"
COPY . .
WORKDIR "/src/ProductReviewAPI"
RUN dotnet publish "ProductReviewAPI.csproj" -c Release -o /app/publish

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProductReviewAPI.dll"]