### Building and running your application

When you're ready, build your application by running:
`docker build -t dumindapium/platformservice . `.

and fire this to run the application in port 8080
`docker run -p 8080:80  -d dumindapium/platformservice`

Your application will be available at http://localhost:8080.

### Deploying your application to the cloud

Then, push it to your registry, e.g. `docker push dumindapium/platformservice`.


### References
* [Docker's .NET guide](https://docs.docker.com/language/dotnet/)
* The [dotnet-docker](https://github.com/dotnet/dotnet-docker/tree/main/samples)
  repository has many relevant samples and docs.