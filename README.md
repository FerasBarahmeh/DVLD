# Driving & Vehicle License Department (DVLD) Project

## Overview

This project is a Windows Forms application developed for the Driving & Vehicle License Department (DVLD). The application aims to streamline the management of driving and vehicle licenses, providing a user-friendly interface for department staff to manage license information efficiently.

## Solution Structure

The solution consists of three main projects:

1. **DVLD**: The main Windows Forms application project.
2. **DVLD Business Layer**: Contains the business logic for the application.
3. **DVLD DataAccess Layer**: Manages data access and interactions with the database.

### DVLD Project Structure

- **Applications**: Contains forms and modules related to applications.
- **Auth**: Manages authentication and authorization.
- **Drivers**: Handles driver-related operations.
- **General Class**: Includes general utility classes used across the application.
- **License**: Manages license-related operations.
- **People**: Handles operations related to individuals within the system.
- **Resources**: Contains resources such as images, strings, etc.
- **Tests**: Includes test cases for various components.
- **User**: Manages user-related operations.

### Main Files

- `frmMain.cs`: The main form of the Windows Forms application.
- `Program.cs`: The entry point of the Windows Forms application.
- `App.config`: Configuration file for the application settings.

## Installation

### Prerequisites

- Visual Studio (2019 or later)
- .NET Framework 4.7.2 or later
- SQL Server (for database management)

### Steps

1. **Clone the Repository**

   ```sh
   git clone https://github.com/FerasBarahmeh/DVLD.git
   cd DVLD
2. Restore DVLD db from DVLD.bak file (SQL Server)
3. Create references between layers
