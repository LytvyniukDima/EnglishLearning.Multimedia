networkName="english-net"
containerName="mongodb"

docker network create english-net
# docker run -d -p 27017:27017 -v ~/data:/data/db --name $containerName --network $networkName mongo
docker run -d -p 27017:27017 --name $containerName --network $networkName mongo
