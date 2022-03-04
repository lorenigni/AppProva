FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
COPY bin/Release/net6.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "API.dll"]
