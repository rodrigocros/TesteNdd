FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/SDK:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TesteNdd.application/TesteNdd.application.csproj", "TesteNdd.application/"]
COPY ["TesteNdd.infrastructure/TesteNdd.infrastructure.csproj", "TesteNdd.infrastructure/"]
COPY ["TesteNDD.domain/TesteNDD.domain.csproj", "TesteNDD.domain/"]
COPY ["TesteNDD.domain/TesteNDD.api.csproj", "TesteNDD.api/"]
RUN dotnet restore "TesteNdd.application\TesteNdd.application.csproj"
COPY . .
WORKDIR "/src/TesteNDD.api"
RUN dotnet "TesteNDD.api.csproj" -c $BUILD_CONFIGURATION -o /app/build 

FROM build AS publish
ARF BUILD_CONFIGURATION=Release
RUN dotnet publish "TesteNDD.api.csproj" c $BUILD_CONFIGURATION -o /app/publish 

FROM base AS finall
workdir /app
COPY --from=publish /app/pubish .
ENTRYPOINT ["dotnet", "TesteNDD.api.dll"]