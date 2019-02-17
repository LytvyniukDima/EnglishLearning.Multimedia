FROM microsoft/dotnet:2.2-sdk AS build

COPY . /app
WORKDIR /app/EnglishLearning.Multimedia.Host
RUN dotnet publish -c Release -o /app/output

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
COPY --from=build /app/output /app/host
WORKDIR /app/host

ENV ASPNETCORE_ENVIRONMENT=Docker
ENV ASPNETCORE_URLS="http://*:8500"

ENTRYPOINT ["dotnet", "EnglishLearning.Multimedia.Host.dll"]
