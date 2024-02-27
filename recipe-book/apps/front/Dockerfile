FROM node:18-bullseye

WORKDIR /front-src

COPY . .

ENV PNPM_HOME=/usr/local/bin

RUN apt update && apt upgrade -y && npm install -g pnpm && \
    pnpm install -g @angular/cli