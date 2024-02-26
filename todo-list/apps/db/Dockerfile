FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /db-src

COPY . .

EXPOSE 1433

CMD /opt/mssql/bin/sqlservr
