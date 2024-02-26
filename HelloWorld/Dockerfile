#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#docker build -f "C:\Users\Alexis Labranche\source\repos\HelloWorld\HelloWorld\Dockerfile" .
# docker exec -it --user=root charming_lewin /bin/sh
# apk update
# apk add install curl


ARG image_prefix=portail-depotspaquets.services.rq/forge-images-docker-remote

FROM ${image_prefix}/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM ${image_prefix}/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HelloWorld/HelloWorld.csproj", "HelloWorld/"]
RUN dotnet restore "./HelloWorld/./HelloWorld.csproj"
COPY . .
WORKDIR "/src/HelloWorld"
RUN dotnet build "./HelloWorld.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HelloWorld.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorld.dll"]

# Pour healthcheck du container
USER root
RUN apk update 
RUN apk add curl
HEALTHCHECK --interval=1m --timeout=3s \
  CMD curl -f http://localhost:8080/healthcheck || exit 1