FROM mcr.microsoft.com/mssql/server:2022-latest

WORKDIR /db-src

COPY . .

EXPOSE 1433

CMD /bin/bash ./entrypoint.sh
