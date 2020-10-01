FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
RUN mkdir /source
WORKDIR /source
COPY *.csproj .
RUN dotnet restore
COPY . .

FROM build as publish
RUN dotnet publish -c release -o /published


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as final
RUN mkdir /app
WORKDIR /app
COPY --from=publish /published .
ENTRYPOINT ["dotnet","DaprExample.StateStore.dll" ]