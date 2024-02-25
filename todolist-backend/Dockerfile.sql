FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /db-src

COPY ./apps/sql .

CMD /opt/mssql/bin/sqlservr
