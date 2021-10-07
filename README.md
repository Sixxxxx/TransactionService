Hello there

This is a microservice application for transactions made by a client.
Before you run the app, ensure all dependencies are up to date with the exception of Microsoft.AspNetCore.Mvc.NewtonsoftJson(install 3.1.17). I've included the migrations folder and there will be no need to update your database as the application does this any time it starts up. 

NOTE: This Application is built on .net 3.1 framework.

Swagger has been integrated into the application which can be accessed at this address 
https://localhost:44359/swagger/index.html and opens up once you run the application
but if you want to use postman, you'll need to export the documentation which can be found in the root of the application

There are two endpoints the Update Transaction and Get transaction


Happy testing