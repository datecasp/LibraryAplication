# LibraryApplication
Backend project developed in Visual Studio 2022.
* C#
* Entity Framework
* SQL SERVER
* Swagger for docs

Represent the back end for the management of a library.
It shows different endpoints to serve the needings of the front end.

# Three layer arquitcture
Following principles of abstraction and security, there are three layers
or levels separated in three Visual Studio independent projects.
* API -> The outter layer. Manages the endpoints and the data flow
         betwen the backend and the frontend.
* Domain -> The middle layer. It holds the logic and models. Comunicates the outter and the inner layers
* Infrastructure -> The inner layer. It has the repositories and configurations to manage the server communication.
# Data structure
There are three main entities in the context. 
* User
* Book
* Category

And two extra entities for N to M relation betwen the main entities
* BookUser -> Represent the relation betwen users and books. A user can have many books.
And a book can have many users (one actual user and many past users, I used a flag for this difference)
* BookCategory -> A book has many categories and a category can be in many books.

# Images
https://github.com/datecasp/LibraryAplication/blob/development/src/images/swagger-api.png

https://github.com/datecasp/LibraryAplication/blob/development/src/images/book.png
# Frontend
The frontend project is here: 
https://github.com/datecasp/LibraryApplication.FrontEnd

It´s developed in Visual Studio and Angular-cli project using typescript, HTML and CSS.

# TODO 
* Add security with login
