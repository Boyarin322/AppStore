# AppStore - Online Shop Web Application

#Description
This is an online clothes shop web application built on ASP.NET Core MVC using MS SQL Server as the database and Entity Framework as the ORM.


#Installation
Clone the repository from GitHub.

Open the solution file (AppStore.sln) in Visual Studio.

Build the solution.

Open Package Manager Console and run the following command to create the database:

sql
Copy code
Update-Database
This will create the necessary tables in the database.

Run the application in Visual Studio.

#Usage
User
A user can do the following:

View products on the home page or by category.
View product details and add products to the cart.
Register and log in to their account.
View their profile and order history.
Checkout and place an order.

#Moderator
A Moderator can do the following:

Can delete users(only),
Can create products.

#Admin
An admin can do the following:

Add, edit, and delete products and categories.
Send mail to all,
View and edit orders.


#Database
The database schema includes the following tables:

Users : UserId, Username, Email, Password(hashed)
Products : ProductId, Productname, Description, Price, Photo(Url to photo)
Carts : Id, UserId(foreign key), ProductId(foreign key)

#Technologies Used
ASP.NET Core MVC
MS SQL Server
Entity Framework
HTML/CSS/JavaScript
Bootstrap

#Credits
This project was built by Nazariy Kozachok [Boyarin322].
