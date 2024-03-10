#!/usr/bin/env bash

SCRIPT_DIR=$(dirname "$0")
DB_USER=SA
DB_PASS=P@ssw0rd1
DB_HOST=localhost
DB_TARGET=hml
CNN_PARAMS_MASTER="-S $DB_HOST -U $DB_USER -P $DB_PASS"
CNN_PARAMS="$CNN_PARAMS_MASTER -d $DB_TARGET"

/opt/mssql-tools/bin/sqlcmd $CNN_PARAMS_MASTER -Q "IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE [name] = '$DB_TARGET') CREATE DATABASE [$DB_TARGET];"

for file in $SCRIPT_DIR/*; do
    if [[ $(basename "$file") =~ ^[0-9] ]]; then
        /opt/mssql-tools/bin/sqlcmd $CNN_PARAMS -i "$file";
    fi
done