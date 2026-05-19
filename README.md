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

Because this application uses a local SQLite database (`clinic.db`), it is **fully portable**. To run it on another computer without installing Visual Studio or copying source code:

1.  Open terminal in the project directory and run the publish command:
    ```bash
    dotnet publish ClinicApp/ClinicApp.csproj -c Release -r win-x64 --self-contained true
    ```
2.  Go to the published directory:
    ```text
    ClinicApp/bin/Release/net472/win-x64/publish/
    ```
3.  Copy the entire `publish` folder onto a USB drive or zip it.
4.  Paste it onto any target Windows computer and run **`ClinicApp.exe`** directly!
