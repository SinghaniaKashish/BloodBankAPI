# BloodBankAPI


# Overview
The Blood Bank Management System API is a RESTful API built with ASP.NET Core, designed to manage blood donations, donor details, and inventory. This project provides a range of endpoints to perform CRUD operations, filter records, handle pagination, and search by attributes like blood type and donation status.

# Features
CRUD operations: Create, Read, Update, and Delete blood bank records.
Search functionality by blood type, status, or both.
Pagination support for large datasets.
Sorting by blood type and filtering based on multiple parameters.
Validation checks to ensure data integrity.

#Endpoints
1. GET - /api/BloodbankApi - Retrieves a list of all blood banks, with optional pagination and search filters.

2. GET - /api/BloodbankApi/{id} - Retrieves details of a specific blood bank by ID.

3. POST - /api/BloodbankApi - Adds a new blood bank to the database.

4. PUT - /api/BloodbankApi/{id} - Updates information for a specific blood bank by ID.

5. DELETE - /api/BloodbankApi/{id} - Deletes a specific blood bank by ID.

6. GET - /api/BloodbankApi/paginate/{page}/{size} - Retrieves a list of donors with pagination filters.

7. GET - /api/BloodbankApi/bloodtype/{bloodType} - Retrieves details of a list of donor by Blood Type.

8. GET - /api/BloodbankApi/status/{status} - Retrieves details of a list of donor by status.

9. GET - /api/BloodbankApi/donorName/{donorName} - Retrieves details of a list of donor by name.

10. GET - /api/BloodbankApi/sortByBloodType - Sort data by Blood type.

11. GET - /api/BloodbankApi/sortByCollectionDate -  Sort data by collection date

12. GET - /api/BloodbankApi/filter - Filter data with status and blood type.

#Sample JSON Payloads

  {
        "donorName": "Piyush Agrawal",
        "age": 37,
        "bloodType": "O+",
        "contactInfo": "1230456789",
        "quantity": 300,
        "collectionDate": "2024-11-01",
        "expirationDate": "2024-10-05",
        "status": "Available"
    }

  #Screenshot
   ![Screenshot (70)](https://github.com/user-attachments/assets/f60044b7-2e11-47b6-b586-ffcde37d5776)
 

