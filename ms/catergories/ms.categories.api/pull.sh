#!/bin/bash
ENV_ALIAS='dev'

API_ALIAS='soa.api'

export AZ_RC_NAME_ID=ntuacontainers.azurecr.io
export AZ_RC_ACCESS_USER_ID=ntuacontainers
export AZ_RC_REGISTRY=ntuacontainers
export AZ_RC_SECRET_PASS_KEY=/noKvfu1YkxN3nPtMLt5xsyGEl8yC+uQ

echo "---------------------------------------"
echo "---------------------------------------"
echo "Azure Arc Login..."
docker login $AZ_RC_NAME_ID -u $AZ_RC_ACCESS_USER_ID -p $AZ_RC_SECRET_PASS_KEY

docker pull $AZ_RC_NAME_ID/$AZ_RC_ACCESS_USER_ID/$API_ALIAS
echo "Pulled ... $AZ_RC_NAME_ID/$AZ_RC_ACCESS_USER_ID/$API_ALIAS"


if [ "$(docker ps -q -f name=sh_server_api_${ENV_ALIAS})" ]; then
    echo "Stopping...API"
    docker stop sh_server_api_${ENV_ALIAS} 
    if [ "$(docker ps -aq -f status=exited -f name=sh_server_api_${ENV_ALIAS} )" ]; then
        # cleanup
        echo "Removing...API"
        docker rm -f sh_server_api_${ENV_ALIAS} 
    fi
fi
    # run the container
    echo "Creating and starting...API"
    docker run \
    --name sh_server_api_${ENV_ALIAS} \
    -p 6200:6200 \
    -d \
    $AZ_RC_NAME_ID/$AZ_RC_ACCESS_USER_ID/$API_ALIAS

    docker logs sh_server_api_${ENV_ALIAS} 
#---------------------------------------------------------------------------------------------------------
