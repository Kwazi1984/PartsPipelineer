#!/bin/bash 
SERVICE=PartsPipelineer.Services
REPOSITORIES=($SERVICE.Tools $SERVICE.Devices PartsPipelineer.Api.Gateway)

for REPOSITORY in ${REPOSITORIES[*]}
do
	echo --------------------------------------------------------
	echo Starting a service: $REPOSITORY
     echo --------------------------------------------------------
     dotnet run -p ../$REPOSITORY/$REPOSITORY/$REPOSITORY.csproj &
done

# dotnet run -p ../PartsPipelineer.Services.Tools/PartsPipelineer.Services.Tools/PartsPipelineer.Services.Tools.csproj
# dotnet run -p ../PartsPipelineer.Services.Devices/PartsPipelineer.Services.Devices/PartsPipelineer.Services.Devices.csproj
