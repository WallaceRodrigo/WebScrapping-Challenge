FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

EXPOSE 80

COPY . ./
RUN dotnet restore
RUN dotnet tool install --global dotnet-ef --version 7.0.4
RUN dotnet publish -c Release -o out

ENV PATH="${PATH}:/root/.dotnet/tools"

RUN dotnet ef database update

ENTRYPOINT ["dotnet", "WebApplication1.dll"]