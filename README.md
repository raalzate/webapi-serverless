# Dotnet Elastic Beanstalk 

Ejemplo realizar una webapi usando docker y los comandos de elastic beanstalk 


## Pre-install
- Install awsebcli (pip install awsebcli)
- Install awscli (pip install awscli)
- Install dotnet (core > 2.1)




# Lifecycle

## 1. Run locally
### Workspace /Instance
```sh
dotnet restore
dotnet run
```

## 2. Runner tests 
### Workspace /InstanceTest
```sh
dotnet test
```

## 3. Verify Pact
### Workspace /PactVerify
```sh
dotnet test
```

## 4. Build
### Workspace /Instance
```sh
./build.ps1
```

## 5. Push to ECR

```sh
export COMPONENT_NAME=instance
export URL_REPO=<Repo ECR>
 
echo "Building image [$COMPONENT_NAME]..."
docker build -t $COMPONENT_NAME .
docker tag $COMPONENT_NAME:latest $URL_REPO/$COMPONENT_NAME:latest

echo "Pushing image [$COMPONENT_NAME]..."
docker push $URL_REPO/$COMPONENT_NAME:latest
```

## 5. Deploy
### Workspace /Instance
```sh
eb deploy
```
### Run container on-premise 
```sh
docker run -d -p 80:80 --name dotnet-instance instance
```

# Documentation

## Update definitions
```sh
aws apigateway import-rest-api --body file://swagger.json --region us-east-1
```

```sh
aws apigateway put-rest-api --rest-api-id <ID-API-GATEWAY> --mode overwrite --body file://swagger.json --region us-east-1
```

## Create Stage Mock
```sh
aws apigateway create-deployment --rest-api-id <ID-API-GATEWAY> --stage-name mock --region us-east-1
```

## Create Environment

```sh
eb init -p docker instance-dev
eb create
```

## Run  Local
```sh
eb local run --port 80
```




