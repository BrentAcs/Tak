FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Tak.CLI/Tak.CLI.csproj", "Tak.CLI/"]
RUN dotnet restore "src/Tak.CLI/Tak.CLI.csproj"
COPY . .
WORKDIR "/src/Tak.CLI"
RUN dotnet build "Tak.CLI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tak.CLI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tak.CLI.dll"]
