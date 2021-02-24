# EventHorizon Platform Docs

# About 

This project is built on Blazor, with a focus on quick page creation. It includes a sidebar that will auto update based on razor files located in the Pages/Docs directory.

# Support

This project supports both Blazor Server and Wasm deployments.

> If using Blazor Wasm the JSON Metadata is not supported, since that requires access to the file system for loading the files.

# Usage

The the only required step is to create a razor file with a [Page] attribute and inherit from the PageMetadataBase class.

Metadata feature:
- A [PageMetadata] attribute, this allow for setting meta information about the page from an attribute.
- Override Page Metadata with a jsonfile, it must match the format of [Razor File Name].razor.json
  - Example Razor File: GettingStarted.razor
  - Example Json File: GettingStarted.razor.json

# More Details

This project created a Side Navigation based on the routes of the pages, so it will nest the routes under "folder" creating a compact tree structure. 

The folders, pulled from the route, will require Resource Keys to be added to the SharedResource.resx to correctly localize.

## Json Format

When creating the json file, you can checkout the details below to get an idea of how the structure/support properties are.

~~~ json
{
    "Title": "Title of the Page",
    "CustomProperties": {
        "@comment": "CustomProperties are a string-string map of any support json characters.",
        "details":  "Some random details"
    }
}
~~~

# Example

You can clone this project and run the solution, checkout the GettingStarted.razor and CreateAMap.razor for examples of how the pages are structured. Any pages, correctly attributed, in the Pages directory should be supported.

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