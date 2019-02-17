imageName="english_multimedia"
containerName="multimedia_service"
networkName="english-net"

docker kill $containerName
docker rm $containerName

docker run -p 8500:8500 --name $containerName --network $networkName $imageName
