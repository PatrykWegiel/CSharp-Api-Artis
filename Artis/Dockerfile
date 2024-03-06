FROM mcr.microsoft.com/dotnet/sdk:5.0
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish ./Artis.Api/Artis.Api.csproj -o /publish/
WORKDIR /publish
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Artis.Api.dll
