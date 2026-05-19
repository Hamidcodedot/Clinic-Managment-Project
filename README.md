# Clinic Management System (CMS)

A lightweight, portable, and highly optimized Windows Forms application for managing clinic operations, built using **C#** and **SQLite** under the **.NET SDK-style** project format.

This project features a clean, separated architecture with code and designer logic isolated into partial classes, providing an easy-to-understand codebase perfect for learning, development, and deployment.

---

## 🌟 Key Features

*   **Dual Portal Authentication**: 
    *   **Staff/Receptionist Panel**: Manage doctor directories, patient profiles, bookings, and monitor clinic stats from a centralized dashboard.
    *   **Patient Portal**: Secure authentication via phone and password. Patients can view their complete appointment history and update passwords.
*   **Doctors Management**: Manage profiles, specialization, consultation fees, available slots, room numbers, and custom working days.
*   **Patients Registry**: Add and update patient information (name, age, gender, phone, address, secure password).
*   **Appointment Scheduler**: Custom scheduling system with automatic slot availability checks based on the selected doctor's schedule and prior bookings.
*   **Dashboard Analytics**: Live statistics showing Total Doctors, Total Patients, Today's Appointments, and Pending requests.
*   **Automated Database Setup**: Built-in SQLite database auto-initialization. No SQL Server installation is required!

---

## 🛠️ Architecture & Structure

The codebase is organized logically following standard C# WinForms guidelines:

```text
ClinicApp/
│
├── Database/
│   ├── DatabaseHelper.cs       # Auto-creates clinic.db & tables on startup
│   ├── UserRepository.cs       # Staff CRUD & Authentication database logic
│   ├── DoctorRepository.cs     # Doctor CRUD database logic
│   ├── PatientRepository.cs    # Patient CRUD & Authentication database logic
│   └── AppointmentRepository.cs # Booking scheduler database logic
│
├── Forms/
│   ├── RoleSelectForm.cs       # Main splash screen for role selection
│   ├── LoginForm.cs            # Staff Login Form
│   ├── MainForm.cs             # Receptionist Dashboard
│   ├── DoctorsForm.cs          # Doctor management form
│   ├── PatientsForm.cs         # Patient directory form
│   ├── AppointmentsForm.cs     # Appointment scheduling and status manager
│   ├── PatientPortalForm.cs    # Patient self-service panel
│   └── *.Designer.cs           # Designer layout code (separated from logic)
│
├── Models/
│   ├── User.cs                 # User entity schema
│   ├── Doctor.cs               # Doctor entity schema
│   ├── Patient.cs              # Patient entity schema
│   └── Appointment.cs          # Appointment entity schema
│
└── Program.cs                  # App entry point (initiates DB and launches RoleSelectForm)
```

---

## ⚙️ Prerequisites & Setup

### Prerequisites
*   [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0, 7.0, or 8.0/9.0)
*   Windows OS (since WinForms is Windows-native)
*   Any text editor (e.g., VS Code) or Visual Studio 2022.

### Step-by-Step Setup
1.  **Clone the Repository**:
    ```bash
    git clone https://github.com/Hamidcodedot/Clinic-Managment-Project.git
    cd Clinic-Managment-Project
    ```
2.  **Build the Project**:
    ```bash
    dotnet build ClinicApp/ClinicApp.csproj
    ```
3.  **Run the Project**:
    ```bash
    dotnet run --project ClinicApp/ClinicApp.csproj
    ```

> [!NOTE]
> On the first run, the application will automatically create a local `clinic.db` file in the output folder and populate it with sample doctors, patients, and receptionist login details.

---

## 🔐 Default Credentials for Testing

To test the application immediately, use the following pre-configured credentials:

### 💼 Staff Panel (Receptionist)
*   **Username**: `admin`
*   **Password**: `admin123`

### 🩺 Patient Portal
*   **Phone**: `0312-9998887`
*   **Password**: `12345`
*(Alternatively, register a new patient; their default password will be their phone number)*

---

## 🚀 How to Run/Deploy on Any Other Computer

Because this application uses a local SQLite database (`clinic.db`), it is **fully portable** and does not require any database installations.

### 📦 Option 1: Use the Pre-Built Portable Package (Easiest)
A pre-built, ready-to-run release package is available at the root of the project: **`ClinicApp_Release.zip`**.

#### How to Deploy & Run:
1.  **Transfer the Zip**: Copy `ClinicApp_Release.zip` to a USB drive or send it to the target Windows computer.
2.  **Extract the Files**: Right-click the zip file and select **Extract All...** to unzip it to a folder of your choice.
3.  **Run the App**: Open the extracted folder and double-click **`ClinicApp.exe`**.
4.  **Database Auto-creation**: The application will automatically initialize a fresh `clinic.db` in that folder on its first startup and pre-populate the tables with default demo data.

---

### 🛠️ Option 2: Build a Custom Release Package from Source
If you want to compile and publish the latest source code yourself:

1.  Open your terminal/command line in the project root directory.
2.  Run the publish command:
    ```bash
    dotnet publish ClinicApp/ClinicApp.csproj -c Release
    ```
3.  Navigate to the publish directory:
    ```text
    ClinicApp/bin/Release/publish/
    ```
4.  Copy the `x64` and `x86` folders containing the native `SQLite.Interop.dll` from `ClinicApp/bin/Release/` into your `publish/` folder (required for SQLite to resolve native binaries on target systems).
5.  Zip the final `publish` folder or copy it directly to your target Windows computer and run **`ClinicApp.exe`**.

