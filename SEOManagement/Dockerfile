#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["SEOManagement/SEOManagement.csproj", "SEOManagement/"]
RUN dotnet restore "SEOManagement/SEOManagement.csproj"
COPY . .
WORKDIR "/src/SEOManagement"
RUN dotnet build "SEOManagement.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SEOManagement.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SEOManagement.dll"]