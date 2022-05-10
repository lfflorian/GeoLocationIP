# Geo API
Geo API, is a web API that provides the location of an IP address, uses the GeoIP2 library and database (https://dev.maxmind.com/geoip?lang=en) to obtain this information.

## Packages
List of all package installed from NuGet
-   MaxMind.GeoIP2
-   Auto Mapper : entity mapper to apply data transfer object

## Project organization
The solution was divided in different class projects with the purpose of having a better organization, implementing the separation of interests and for its scalability and maintenance.

-   Entities: were its defined the entities
-   Web Api: the main project
--  Controllers : definition of the controllers
--  middleware : utilities classes using as middleware 
--  Model : definition of models and entities used inside web api project
-- service: The layer where the specific functionalities of the project are found, such as obtaining the location

## Features
Description of different features implemented on project
-   Docker : using docker to containerize the application and run on different computers in linux server
-   Dto : Data Transfer object, used for separate entities that communicate with different services
-   Handling Error Globally : static class used for handling error globally, with this, we can have a clean controllers without try catch
-   Action Filter : used for validate the user request schema
-   Asynchronous : used asynchronous code for avoid performance bottlenecks and improve the responsiveness of our application
-   IoC : registration of services and tools for access by constructor injection

## How To Run
for run this web api with docker, just only run the docker-compose.yaml file with:
```
docker-compose up -d
```

there are 2 methods for test:
## GET 

the web api is running in 5050 port, so, use the get method with the next url:
http://localhost:5050/api/Geolocation?ip=IP_to_request

example:

http://localhost:5050/api/Geolocation?ip=141.7.255.74

you will get the following response

```
{
    "ip": "141.7.255.74",
    "geolocation": "Germany",
    "found": true
}
```

were *ip* is the ip requested, *geolocation* is the location from that ip and *found* is used only for to know if the ip was found, true on this case.

## POST

the url for post method is:
http://localhost:5050/api/Geolocation

in the body of the request we send and array of ip objects like this:

```
[
    { "ip": "23.2.1.8" },
    { "ip": "2.22.1.8" },
    { "ip": "255.25.1.8" }
]
```

and the response you will get is:

```
[
    {
        "ip": "23.2.1.8",
        "geolocation": "United States",
        "found": true
    },
    {
        "ip": "2.22.1.8",
        "geolocation": "Sweden",
        "found": true
    },
    {
        "ip": "255.25.1.8",
        "geolocation": null,
        "found": false
    }
]
```
