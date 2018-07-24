# prodi
A RESTful web service built with the ASP.NET Web API platform using C#.
## Prerequisites
You will need the following:
   - [.NET Core SDK 2.1](https://www.microsoft.com/net/download)
   - [Postman IDE](https://www.getpostman.com/)
## Using the API
### Step 1: Cloning the repository
To do this, either click on the 'Clone or download' button on the Github page or type the following into terminal:
```sh
$ git clone https://github.com/amycheevers/prodi.git
```
### Step 2: Running
Within the terminal, navigate inside of the prodi project folder, and type the following:
```sh
$ dotnet run
```
### Step 3: Accessing
The Web API will be running on http://localhost:6134.
##### Using Postman
I have created a collection that contains an example of different requests, which can be found [here](https://www.getpostman.com/collections/a1b24edb9faca4701ee6).
The requests I've set up are:
   - GET http://localhost:6134/api/products - will return all products
   - GET http://localhost:6134/api/products/{id} - will return product with {id} if it exists
   - GET http://localhost:6134/api/products?description=AAA - will return all products filtered by description of 'AAA'
   - DELETE http://localhost:6134/api/products/{id} - will return with success message if product with {id} deleted successfully
   - POST http://localhost:6134/api/products, Body: { "Description": "testing", "Model": "testing", "Brand": "testing" } - will return with success message when added
   - PUT http://localhost:6134/api/products/{id}, Body: { "Description": "testing" } - will return with success message when updated
### Step 4: Testing
Within the terminal, navigate inside of the Tests project folder, and type the following:
```sh
$ dotnet test prodi.Tests.csproj
```
