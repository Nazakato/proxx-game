# Proxx Game
## Example
Playable game and rules can be found here: [Proxx](https://proxx.app/).
## Prerquisites
- To run the app you need [Docker](https://www.docker.com/products/docker-desktop) installed on your machine and docker daemon is running;
- Powershell, windows cmd or any other shell;
- The docker fetches .NET 7.0 runtime, so if you don't have it in your cache, the first run might take up to several minutes, depending on the characteristics of your machine.
## Powershell
The next command builds the image and runs it at once, cleaing the resources after the app execution finishes:
```
docker run -it --rm $(docker build -q -f Dockerfile .)
```
## Shell-agnostic way
Run the commands line by line.
### Running the application:
```
docker build -t proxx-game-image -f Dockerfile .
docker run -it --rm proxx-game-image
```
### Cleaning up resources:
```
docker rmi proxx-game-image:latest
docker rmi mcr.microsoft.com/dotnet/sdk:7.0
docker rmi mcr.microsoft.com/dotnet/runtime:7.0
```