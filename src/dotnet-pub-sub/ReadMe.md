# Pub Sub Sample using dapr
- Install dapr cli from the official source and make sure *dapr init* is ran properly.
- You need to have docker installed.
- Run a rabbit mq container using following command. *Optional, If you have already rabbitmq installed*
```sh
docker run -d --hostname my-rabbit -p 5672:5672 --name some-rabbit rabbitmq:3
```

Run following commands to run the application

```
dotnet restore
dapr run --app-id pubsub-order --app-port 5010 --components-path .\components\ dotnet run
```