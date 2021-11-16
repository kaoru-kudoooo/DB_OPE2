#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DB_Ope_API/DB_Ope_API.csproj", "DB_Ope_API/"]
RUN dotnet restore "DB_Ope_API/DB_Ope_API.csproj"
COPY . .
WORKDIR "/src/DB_Ope_API"
RUN dotnet build "DB_Ope_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DB_Ope_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DB_Ope_API.dll"]