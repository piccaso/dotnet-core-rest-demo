FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# copy everything build
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/DncRestDemo/out/ .
ENTRYPOINT ["dotnet", "DncRestDemo.dll"]