# Recipe Box

### By Spencer Moody, Allison Sadin, and Noel Kirkland

•[Stories](#1)<br>
•[Setup](#2)<br>
•[Bugs](#3)<br>
•[Contact](#4)<br>
•[Tech](#5)<br>
•[License](#6)

## Description

This project will allow users to create, read, edit, and delete their favorite recipes. The user will be able to create their own account that they can use to log on/off with. Though all users of the application will be using one shared database, each user will only be able to see and interact with the recipes that they themselves have created.

## User Stories <a name="1"></a>

* As a user, I want to add a recipe with ingredients and instructions, so I remember how to prepare my favorite dishes.

* As a user, I want to tag my recipes with different categories, so recipes are easier to find. A recipe can have many tags and a tag can have many recipes.

* As a user, I want to be able to update and delete tags, so I can have flexibility with how I categorize recipes.

* As a user, I want to edit my recipes, so I can make improvements or corrections to my recipes.

* As a user, I want to be able to delete recipes I don't like or use, so I don't have to see them as choices.

* As a user, I want to rate my recipes, so I know which ones are the best.

* As a user, I want to list my recipes by highest rated so I can see which ones I like the best.

* As a user, I want to see all recipes that use a certain ingredient, so I can more easily find recipes for the ingredients I have.

## Setup/Installation Requirements <a name="2"></a>

* _Install the .NET framework_
  1. _This program utilizes .NET version 3.1, and requires [this framework to be pre-installed](https://dotnet.microsoft.com/download/dotnet-core/3.1)_

* _Install and configure MySQL_
  1. _This program utilizes MySQL Community Server version 8.0.15 and requires [this to be pre-installed](https://dev.mysql.com/downloads/file/?id=484914). Click the link at the bottom that reads "No thanks, just start my download"_
  2. _Use Legacy Password Encryption and set password to "epicodus"_
  3. _Click "Finish_

* _Download this application from HitHub_
  1. _Open the following web address in your browser: **`https://github.com/Smoody0208`**_
  2. _Click on the button labeled_ Repositories
  3. _Navigate into the **`RecipeBox.Solution`** repository and click the green button labeled "Clone or download" and download the zip to your computer_

* _Install the MySQL database_
  1. _Open the downloaded application in a text editor ([V.S. Code preferred](https://code.visualstudio.com/))_
  2. _Open a new terminal in your text editor (Ctrl+\` in V.S. Code) and run command `> echo 'export PATH="$PATH:/usr/local/mysql/bin"' >> ~/.zprofile`_
  3. _Enter the command `> source ~/.zprofile` to confirm MsSQL has been installed_
  4. _Connect to MySQL by running the command `> mysql -uroot -pepicodus`_
  5. _Install the necessary MySQL database by copying the code block below and entering it into your terminal_
  6. _Once the following code block has been entered you will close MySQL by running the command `> exit`_

```
    SCHEME CREATE STATEMENT GOES HERE!!!
```

* _Run the application_
  1. _In the terminal, navigate to the project directory by running the command `> cd RecipeBox`_
  2. _Now that we are in the RecipeBox directory you will run the command `> dotnet restore`_
  3. _Once the "obj" folder has initialized you will run the command `> dotnet run`_
  4. _Go to http://localhost:5000/ in your preferred browser to use the application_


## Known Bugs <a name="2"></a>

There are no known bugs at this time

## Support and Contact Details <a name="3"></a>

If there are any issues or questions contact us through GitHub

## Technologies Used <a name="4"></a>

*  C#/.NET
*  MySQL
*  HTML
*  CSS
*  Markdown


### License <a name="5"></a>

*This project uses the following license: [MIT](https://opensource.org/licenses/MIT)*

Copyright (c) 2020 **_Noel Kirkland LLC_**