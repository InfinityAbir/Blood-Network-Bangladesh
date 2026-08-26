FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/BloodNetwork.Domain/BloodNetwork.Domain.csproj src/BloodNetwork.Domain/
COPY src/BloodNetwork.Application/BloodNetwork.Application.csproj src/BloodNetwork.Application/
COPY src/BloodNetwork.Infrastructure/BloodNetwork.Infrastructure.csproj src/BloodNetwork.Infrastructure/
COPY src/BloodNetwork.Api/BloodNetwork.Api.csproj src/BloodNetwork.Api/
RUN dotnet restore src/BloodNetwork.Api/BloodNetwork.Api.csproj

COPY src/ src/
RUN dotnet publish src/BloodNetwork.Api/BloodNetwork.Api.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_ROLL_FORWARD=LatestMajor
ENV DOTNET_HOSTBUILDER__RELOADCONFIG=false

EXPOSE 8080
ENTRYPOINT ["dotnet", "BloodNetwork.Api.dll"]
