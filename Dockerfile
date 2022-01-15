#Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

#Copy the CSPROJ file and restore any dependencies (via NUGET). Subsequently publish
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out 

#Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","BE-IoRT.dll"]

