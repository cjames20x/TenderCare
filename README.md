# 🏥 TenderCare Healthcare Management System

TenderCare is a web-based healthcare platform built with ASP.NET Core MVC. It provides a seamless experience for patients to manage their appointments and medical history, while offering administrators a powerful dashboard for system oversight.

## 🌟 Project Overview
This system solves the problem of manual patient record-keeping by providing a digital portal. It uses **Role-Based Access Control (RBAC)** to ensure that patients only see their own history, while admins can see the entire clinic's operations.

## 🛠️ Tech Stack
* **Framework:** ASP.NET Core MVC 6.0/8.0
* **Language:** C#
* **Database:** MySQL / MariaDB (Lower-case naming convention)
* **ORM:** Entity Framework Core (Database-First approach)
* **Frontend:** HTML5, CSS3, JavaScript, Bootstrap
* **Auth:** Cookie-Based Authentication

## 📂 System Components

### 1. Models (Data Structures)
* **User:** Handles login credentials, emails, and roles (`Admin` vs `User`).
* **Patient:** Stores clinical data like Guardian Name, Contact Number, and Address.
* **Appointment:** Manages scheduling, service types, and appointment status.

### 2. Controllers (Logic)
* **AccountController:** Manages `Login`, `Signup`, and `Logout` functionality.
* **AdminController:** Restricts access to administrative tools and dashboards.
* **HomeController:** Serves the main landing pages and the patient-specific "My History" view.

### 3. Data Context
* **TenderCareDbContext:** Bridges the C# objects to the SQL database using Fluent API mapping for lowercase table names (`users`, `patients`, `appointments`).

## 🚀 How to Run the Project

### Prerequisites
* Visual Studio 2022
* .NET SDK 6.0+
* MySQL Server / Workbench

### Setup Steps
1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/yourusername/tendercare.git](https://github.com/yourusername/tendercare.git)
    ```

2.  **Database Configuration:**
    Execute the following SQL to ensure your table structure is correct:
    ```sql
    CREATE TABLE users (
        UserID INT AUTO_INCREMENT PRIMARY KEY,
        FirstName VARCHAR(255) NULL,
        Email VARCHAR(255) NOT NULL UNIQUE,
        Password VARCHAR(255) NOT NULL,
        Role VARCHAR(50) DEFAULT 'User'
    );
    ```

3.  **Update Connection String:**
    Open `appsettings.json` and update the `DefaultConnection` with your database password.

4.  **Run Application:**
    Open the `.sln` file in Visual Studio and press **F5**.

## 🔐 Access Credentials
| Role | Email | Password |
| :--- | :--- | :--- |
| **Administrator** | admin@tendercare.com | admin123 |
| **Patient/User** | (Register via Signup) | (Your choice) |

---
*Developed as a Healthcare Software Solution.*
