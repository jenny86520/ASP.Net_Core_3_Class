#Create Docker File:
#>Docker: Add Docker Files to Workspace > ASP .NET Core > Windows > 80, 443
#Build Docker File:
#>Docker Images: Build Image
#Run
#docker run -d -p 80:80 signalrchat

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["SignalRChat.csproj", "./"]
RUN dotnet restore "./SignalRChat.csproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "SignalRChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalRChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalRChat.dll"]
