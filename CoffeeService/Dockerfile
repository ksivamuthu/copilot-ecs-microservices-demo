FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CoffeeService/CoffeeService.csproj", "CoffeeService/"]
RUN dotnet restore "CoffeeService/CoffeeService.csproj"
COPY . .
WORKDIR "/src/CoffeeService"
RUN dotnet build "CoffeeService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoffeeService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoffeeService.dll"]
