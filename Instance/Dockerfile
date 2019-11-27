# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /opt/microservicio
ADD out /opt/microservicio
EXPOSE 80

RUN mkdir -p /opt/microservicio/external

ENTRYPOINT ["dotnet", "instance.dll"]

