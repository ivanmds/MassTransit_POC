FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Onboar.Api/Onboar.Api.csproj", "Onboar.Api/"]
RUN dotnet restore "Onboar.Api/Onboar.Api.csproj"
COPY . .
WORKDIR "/src/Onboar.Api"
RUN dotnet build "Onboar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboar.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboar.Api.dll"]