# Manager
# ADO.NET Product & Category Manager

## 🔍 Features

* 📁 View all categories from the database
* 🛒 View all products
* ➕ Add new categories
* 🆕 Add new products
* 🔗 Link products to their categories
* 🔄 Data is updated immediately after each operation

## 📌 Overview

Console application demonstrating basic ADO.NET usage with SQL Server. Supports inserting and retrieving categories and products, validating category existence, and displaying table contents.

## 🛠 Technologies Used

* C# (.NET Console Application)
* SQL Server
* ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`)

## 📑 Database Structure

### Categories Table

* **ID** (int, Identity)
* **Category_Name** (nvarchar)

### Products Table

* **ID** (int, Identity)
* **Category_ID** (int, FK)
* **Product_Name** (nvarchar)
* **Description** (nvarchar)
* **Price** (float / decimal)
* **ImagePath / ImageURL** (nvarchar)

## ▶ Program Flow

1. User inserts categories
2. User inserts products
3. Application validates category existence
4. Data is stored in SQL Server
5. Console displays the updated table contents

## 📘 How to Use

1. Update the connection string in `Program.cs`:

```
string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=Manager;Integrated Security=True;Trust Server Certificate=True";
```

2. Run the program and follow console instructions
3. Add or view categories and products

## 🔧 Future Add-ons

* Update & delete using `SqlDataAdapter`
* Add SQL Profiler screenshot
* Add exception handling
* Add class-based structure for data models
