# Use the ASP.NET Core runtime image based on Alpine Linux
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080

# Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ContactManagementApi.csproj", "./"]
RUN dotnet restore "./ContactManagementApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet publish "ContactManagementApi.csproj" -c Release -o /app --self-contained true --runtime linux-musl-x64

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["./ContactManagementApi"]