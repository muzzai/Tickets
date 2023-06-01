FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DiscountService/src/DiscountService.Web/DiscountService.Web.csproj", "DiscountService/src/DiscountService.Web/"]
COPY ["DiscountService/src/DiscountService.Infrastructure/DiscountService.Infrastructure.csproj", "DiscountService/src/DiscountService.Infrastructure/"]
COPY ["DiscountService/src/DiscountService.Core/DiscountService.Core.csproj", "DiscountService/src/DiscountService.Core/"]
RUN dotnet restore "DiscountService/src/DiscountService.Web/DiscountService.Web.csproj"
COPY . .
WORKDIR "/src/DiscountService/src/DiscountService.Web"
RUN dotnet build "DiscountService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscountService.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscountService.Web.dll"]
