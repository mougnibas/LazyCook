FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

WORKDIR /source

COPY *.sln .
COPY src/ src/
COPY test/ test/
COPY stylecop.json ./
RUN dotnet restore
RUN dotnet publish --configuration Release --output /app --no-restore --runtime linux-x64

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
#ENTRYPOINT ["dotnet", "aspnetapp.dll"]