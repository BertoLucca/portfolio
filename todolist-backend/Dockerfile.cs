FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /api-src

COPY ./apps/api .

RUN apt update && apt upgrade
