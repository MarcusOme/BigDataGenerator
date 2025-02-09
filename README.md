# BigDataGenerator

## Project info
This project is currently an alpha version of big-data analysis. Actually is capable of creatig huge amount of data using a NetCore 3.0 interface using Blazor and MSSQL server as backend data storage solution.

The goal of the project is to create a database that can simulate a medium dimension e-commerce web site. The web part is used as controller to access the database and create the records. Is also possible to decide the number of record for each table inside the database.

## Requirements
This project requires several components to be installed and used on your machine:

- Visual studio 2019 preview (to get access to NetCore 3.0 and Blazor)
- Blazor (correctly configured and installed on host system)
- SQL Express or developer edition (for the creation of the database)

All the others packets should come inside the app or being gathered by the first compilation of the project by the usage of csproj file inside the project.

## Folder structure
There are two main folders inside the project:

- WebApp: contains the Visual Studio Blazor project;
- DB: contains scripts for generating the database in MSSQL;

## Make the project work
In order to make the project work is necessary following those steps:

- Create the database by using the scripts provided inside the repository. Remember that this setup is minimal, feel free to expand it if you need (also remember to change the code in web app also);

- Open the project in Visual Studio Preview and search for the class DataAccessgeneral.cs and substitute the connection string with your own string;

- Debug the project;

- On the web page that opens you will find 3 buttons, each one create records for one of the three tables that are created (using those provide only minimal configuration);

- You can also use the ML approach implemented inside the project, inserting purchase based on reccomendation algorithm.

## Machine learning approach
In order to fill the purchase table with more meaningful data an algorithm based on matrix factorization have been used to create a series of purchase based on the suggested product created inside a list (see [here](https://github.com/dotnet/machinelearning-samples/tree/master/samples/csharp/getting-started/MatrixFactorization_ProductRecommendation)).
For the final user is possible to set a desired threshold for the purchase insertion probability percentage (I have decided for a 20% initial). Also is possible to rerun the algorithm multiple times to insert more purchase based on the ones that are already present.

## Extra
Originally this work was created on EF Core 6 as database access model. Inside the project the line of code that were using this method are already present. If you want to use them remember to change the table name as tblCoreUser for example.
