#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Test2.MVC/Test2.MVC.csproj", "Test2.MVC/"]
RUN dotnet restore "Test2.MVC/Test2.MVC.csproj"
COPY . .
WORKDIR "/src/Test2.MVC"
RUN dotnet build "Test2.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test2.MVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test2.MVC.dll"]