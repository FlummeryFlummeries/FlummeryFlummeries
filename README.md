# Lab 26 - ECommerce App

*Authors: Paul Rest & Nicco Ryan*

[Live Site](https://flummeryflummeries.azurewebsites.net/)

----

### Description

A ASP.Net MVC wep app for showing a selection of Flummery Flummeries, i.e. flummery dessert with a flummery compliment, for sale.

Employs ASP.Net Core Identity and Authentication to allow users to create users, log in, and for certain functionalities to be locked down for admins. Captures a user's supplied Full Name as a claim on registration to display to them in the navbar.

Front-end is dynamically rendered using Razor Pages and Bootstrap with an MVVM-type relationship.

Dependency injection is used to define the relationship between Razor Page's View Models and their services.

---

### Getting Started
Clone this repository to your local machine.

In a command line environment with Git installed:

```
git clone GIT REPO URL HERE
```

### To Run the Program from Visual Studio (2019):

#### Download and Open Project

Select ```File``` -> ```Open``` -> ```Project/Solution```

Next navigate to the directory you cloned the repository to.

Double click on the ```ECommerce-App``` directory.

Then select and open ```ECommerce-App.sln```

#### Get Project Ready to Run Locally

Open the Package Manager Console (```View -> Other Windows -> Package Manager Console``` or on Windows, Alt + V + E + O). If Migrations folder is present, you can skip the next step.

Create the database migrations by entering into the Package Manager Console: ```add-migration -context StoreDbContext <<MIGRATION NAME>>``` and ```add-migration -context UserDbContext <<MIGRATION NAME>>``` where "MIGRATION NAME" is a designation of your choosing.

Update/create the databases by entering into the Package Manager Console: ```update-database -context StoreDbContext``` and ```update-database -context UserDbContext```.

Confirm that the databases have been created and are seeded with data.

#### Run

Select ```Debug``` -> ```Start Debugging``` to the run the app with the debugger

OR

Select ```Debug``` -> ```Start Without Debugging```

---

### Version

v1.5

### Change Log

#### 2020-08-15
- Converted app's services to using entity objects rather than View Models after encountering complexities with VMs

#### 2020-08-13
- Completed Image Upload Service.
- Added Administrator role and authorized routes to appropriate policies.

#### 2020-08-12
- Started image upload service.
- Overhauled UI for a better experience.

#### 2020-08-11
- Added InventoryManagement service.
- Added user handling including registration, login and logout.

#### 2020-08-10
- Initial version using CSV for products.

