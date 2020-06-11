# Pub Sub Sample using dapr
- Install dapr cli from the official source and make sure *dapr init* is ran properly.

Run following commands to run the application
```
dotnet restore
dapr run --app-id pubsub-order --app-port 5010 dotnet run
```