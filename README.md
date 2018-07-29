# Movie API

The Movie API is a AspNetCore API responsible for CRUD operations on a MySql database.

## Getting Started

This API is just a part of a micro service architecture.
If you want to know more about the Social Networks Project, checkout our [Wiki](https://joaopedropio.github.io).

### Prerequisites

* **[DotNet Core SDK](https://www.microsoft.com/net/download)**

### Installing and Running

To build the project, just do:
```
$ dotnet build
```

To run the project, you need to have a instance of MySql running the following Environment Variables set:
```
DBServer=<IP or DNS of the Mysql Server>
DBName=<Database Name>
DBUser=<Database User>
DBPass=<User Password>
```

Then, you can run the API:
```
$ dotnet run
```

## Deployment

To deploy this project, you'll need the following programs:

* **[docker](https://docs.docker.com/engine/installation/)**
* **[docker-compose](https://docs.docker.com/compose/install/)** *(only for MAC and linux)*

The docker-compose will take care of everything: it will download the images e run the containers for you.

Run the commands below to get up the service:

```
docker-compose up
```

And you'll have the API running on **[http://localhost/](http://localhost/)**