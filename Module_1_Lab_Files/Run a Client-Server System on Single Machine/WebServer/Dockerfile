# Build
FROM microsoft/aspnetcore-build AS builder

WORKDIR /source
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --output /app/ --configuration Release

# Run
FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=builder /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebServer.dll"]
