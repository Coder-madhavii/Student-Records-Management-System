# Student Records Management System

## Overview
The **Student Records Management System** is a Windows Forms application developed in C# that allows educational institutions to manage student data effectively. The application provides an intuitive user interface for performing CRUD (Create, Read, Update, Delete) operations on student records stored in a MySQL database.

## Features
- **Add New Student Records**: Easily input student details, including ID, name, course, branch, email, and contact number.
- **View Student Records**: Display all student records in a user-friendly grid view.
- **Update Existing Records**: Modify details of existing students directly from the grid.
- **Delete Records**: Remove student records from the database.
- **Search Functionality**: Search for students by name, course, branch, or email.

## Technologies Used
- **C#**: The primary programming language for the application.
- **Windows Forms**: Used for creating the graphical user interface.
- **MySQL**: Database management system to store student records.
- **MySql.Data**: MySQL Connector/NET library for database connectivity.

## Prerequisites
To run this application, you need to have the following installed:

- Visual Studio or any C# IDE.
- MySQL Server (version 5.7 or higher).
- MySQL Workbench (optional, for managing your database).

## Installation
1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/Coder-madhavii/Personal_Finance_Manager.git
   ```
2. Open the solution file (`.sln`) in Visual Studio.

3. Set up the MySQL database:
   - Create a database named `windowsformsapp_data`.
   - Create a table named `wfp_datatable` with the following structure:
   ```sql
   CREATE TABLE wfp_datatable (
       studentId INT PRIMARY KEY,
       name VARCHAR(100),
       course VARCHAR(100),
       branch VARCHAR(100),
       email VARCHAR(100),
       contactNo BIGINT
   );
   ```
4. Update the connection string in the `DatabaseConnection` class (if necessary) to match your MySQL configuration.
5. Build and run the application.

## Usage
- Launch the application.
- Use the input fields to add new student records.
- Click on a record in the grid to load it into the input fields for updating or deletion.
- Use the search bar to filter records based on student details.

## Contributing
Contributions are welcome! If you would like to contribute, please fork the repository and submit a pull request.
