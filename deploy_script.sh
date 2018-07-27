#!/bin/sh

echo "${DOCKER_PASSWORD}" | docker login ${DOCKER_SERVER} --username "${DOCKER_USERNAME}" --password-stdin
docker-compose -f ./docker-compose.production.yml down
docker-compose -f ./docker-compose.production.yml pull
docker-compose -f ./docker-compose.production.yml up -d
