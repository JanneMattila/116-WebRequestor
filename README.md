# Web Requestor

This example deploys Azure Functions application.
It will support single api with `/api/get` endpoint.
You can pass url parameter to be invoked using `url` query parameter.
Example:

```cmd
/api/get
/api/get?url=https://bing.com
/api/get?url=https://github.com
/api/get?url=https://azure.microsoft.com/en-us/services/devops/
/api/get?url=http://echo.jannemattila.com
```

You can then view Application Map from Azure Portal to
show the automatically collected dependencies.

Example Rest Client code:

```
@endpoint = http://localhost:10023

### Missing 'url' query parameter (400)
GET {{endpoint}}/api/get

### With parameter and large payload (200)
GET {{endpoint}}/api/get?url=http://bing.com

### With parameter and large payload (200)
GET {{endpoint}}/api/get?url=https://github.com

### With parameter and large payload (200)
GET {{endpoint}}/api/get?url=https://azure.microsoft.com/en-us/services/devops/

### With parameter and small payload (500)
GET {{endpoint}}/api/get?url=http://echo.jannemattila.com
```
