# ClientOrderApp
CRUD (Create, Read, Update, Delete) application built with C# and ASP.NET Core

# Getting Started with CRUD

This guide will help you set up and run the CRUD project using cs.

## Prerequisites

 - .NET SDK 9.0 or later
   
 Make sure you have .NET SDK installed on your system. You can download it from the official website: [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

## Cloning the Repository

Clone the project repository using Git:

```sh
git clone https://github.com/AlexPlec/ClientOrderApp.git
```

Then, navigate into the project directory:

```sh
cd ClientOrderApp
```

## Step 1: Building and Running the Application

Before running the project, you need to install the necessary dependencies. Use the following command to install them:
 
 ```sh
dotnet restore
```

## Step 2: Update Database

Before running the project, you need to update the necessary dependencies for database. Use the following command to install them:

```sh
dotnet ef database update
```

## Step 3: Run the Project

Once the dependencies are installed, you can start the project by executing the main script:

```sh
dotnet run
```
