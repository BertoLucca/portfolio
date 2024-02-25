FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /api-src

COPY ./apps/api .

EXPOSE 5000
EXPOSE 8080

RUN apt update && apt upgrade
RUN apt install -y wget
RUN wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb && rm packages-microsoft-prod.deb && apt update
RUN apt install -y dotnet-sdk-8.0
