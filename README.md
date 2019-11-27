# Dotnet Lambda Function AWS

Ejemplo realizar una webapi usando serverless framework

## Pre-config
dotnet new webapi
dotnet restore
dotnet run

## Tool install
dotnet tool install --global Amazon.Lambda.Tools --version 3.0.1
dotnet tool update -g Amazon.Lambda.Tools

## Build
.\build.ps1

## Deploy
serverless deploy -v -p FuncLambda

## Update 
aws apigateway import-rest-api --body file://swagger.json --region us-east-1
aws apigateway put-rest-api --rest-api-id t855dxehoe --mode overwrite --body file://swagger.json --region us-east-1

## Create Stage Mock
aws apigateway create-deployment --rest-api-id ffrogq4xk8 --stage-name mock --region us-east-1


docker build -t instance-dev .

docker run -d -p 80:5000 --name dotnet-instance instance-dev

