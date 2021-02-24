# EventHorizon Platform Docs

# About 

This project contains the Platform Documentation for Game Development Platform available from https://ehzgames.studio.

# Project Structure Details

On application startup the Side Navigation is created based on annotated pages, and will nest '/' routes/path parameters under "folder" creating a compact tree structure. 

The folders, pulled from the route, include Resource Keys added to SharedResource.resx that will also localize.

# Creating a Docker Image

I have included a docker image, that can be used to package up the generated docs site for easy usage in just about any enjoinment.

~~~ bash
docker build -t <docker-org>/docs:latest .
~~~

# Push Docker Image to Registry

~~~ bash
docker push <docker-org>/docs:latest
~~~

# Generate Static Pre-Rendered Output Files

This process uses the Static.PreRenderer project to spin up an InMemory Host of the Server Project, that that then goes through all the registered Routes generating a base, a gzipped compressed and a brotli compressed version of the page into the output/wwwroot folder.

~~~ bash
# Using sh you can generate the files
sh prerender-site.sh
~~~

~~~ powershell
# Using Powershell you can generate the files
./build.ps1
~~~

Inspiration for the Pre-Rendering was from the blog of Andrew Lock. The post most of the Pre-Renderer was derived from is here https://andrewlock.net/enabling-prerendering-for-blazor-webassembly-apps/
