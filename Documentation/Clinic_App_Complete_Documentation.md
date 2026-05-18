# CLINIC MANAGEMENT SYSTEM (ClinicApp)
## Complete Academic Documentation & Technical Manual
**Developed in: C# Windows Forms (.NET Framework / .NET Core) & SQLite**

---

## SECTION 1: TITLE PAGE & PROJECT OVERVIEW

### 1.1 Project Title
**Clinic Management System (ClinicApp)**

### 1.2 Target Audience
Mid-sized healthcare clinics, medical practitioners, reception staff, and patients.

### 1.3 Developer Notes
This system is engineered for maximum portability, modular code design, robust database safety, and dynamic, screen-responsive layouts. It eliminates setup overheads using an embedded serverless relational database engine.

---

## SECTION 2: SOFTWARE REQUIREMENTS SPECIFICATION (SRS)

### 2.1 Project Purpose & Objectives
The primary objective of the **Clinic Management System** is to automate and streamline the day-to-day operations of a medical clinic. It replaces manual registers and complex spreadsheet trackers with a fast, secure, and user-friendly desktop application.

Key objectives:
*   Maintain an active directory of doctors, including their contact info, specialized departments, consultation fees, and weekly schedules.
*   Track patient records (Names, Phone Numbers, Addresses, Ages, and Genders).
*   Schedule patient consultations with specific doctors, maintaining real-time tracking of booked time slots to prevent scheduling conflicts.
*   Provide a dedicated Patient Self-Service Portal to view consultation logs, doctor instructions, and update account credentials.

### 2.2 System Users & Roles
The system accommodates two distinct roles:
1.  **Staff/Receptionist (Administrative)**: Has full administrative rights to add/edit doctors, manage patient lists, schedule appointments on behalf of patients, update consulting statuses, and view live dashboard statistics.
2.  **Patient (Self-Service)**: Accesses a portal using their phone number and a secure password. Can view past appointments, doctor consultation notes, and update their password.

### 2.3 Functional Requirements (FR)
*   **FR-1: Role-Based Routing**: On startup, the application prompts the user to select their role. Choosing "Staff" directs to the Staff Login Form, while "Patient Portal" launches the Patient Workspace.
*   **FR-2: Admin/Staff Authorization**: Access to the administrative dashboard requires standard credential verification against the secure database.
*   **FR-3: Doctor Directory CRUD**: Administrative staff can register new doctors, modify their profile details (fees, room numbers, specialized departments), and remove doctor files from the database.
*   **FR-4: Real-Time Dynamic Search**: Staff can search doctors instantly by name or specialization using an auto-refreshing search field.
*   **FR-5: Patient Profile Auto-Registration**: Receptionists can register patients. If booked on behalf of a patient, the system auto-registers them, using their phone number as a default password for portal access.
*   **FR-6: Appointment Scheduling & Validation**: Bookings require choosing a patient, doctor, date, and time slot. The system checks occupied slots dynamically to avoid double-bookings.
*   **FR-7: Live Dashboard Metrics**: The home dashboard displays live, calculated counters for Total Doctors, Total Patients, Today's Scheduled Appointments, and Pending Appointments.
*   **FR-8: Patient Portal Authentication**: Patients log in securely using their phone number and password.
*   **FR-9: Patient History View**: Shows a historical log of their consulting dates, times, specialist names, and notes.
*   **FR-10: Self-Service Password Management**: Allows patients to change their portal login password instantly.

### 2.4 Non-Functional Requirements (NFR)
*   **NFR-1: Portability**: Zero-installation database requirement. Must run immediately on double-click on any standard Windows machine.
*   **NFR-2: Security (SQL Injection Immunity)**: Absolute implementation of SQL parameterization. No dynamic string concatenation is allowed in SQL commands.
*   **NFR-3: Concurrency & Performance**: Safe utilization of the `using` pattern in C# to prevent database resource starvation or deadlocks by closing all connections immediately after execution.
*   **NFR-4: UX Responsiveness**: Forms must scale gracefully. Dashboard stats cards and navigation panels must dynamically align and center themselves relative to the container size upon window maximization or resizing.
*   **NFR-5: Self-Healing Architecture**: Automatic database construction and migration on startup if the database file is missing or out-of-date.

---

## SECTION 3: SYSTEM ARCHITECTURE & COMPONENT LAYOUT

The application is structured using the **3-Tier / Repository Pattern Architecture**. This isolates the user interface from direct database manipulation, producing highly modular, easily testable, and clean code.

```mermaid
graph TD
    subgraph Presentation Layer (UI)
        RoleSelectForm["RoleSelectForm (Startup UI)"]
        LoginForm["LoginForm (Staff Login)"]
        MainForm["MainForm (Dashboard)"]
        DoctorsForm["DoctorsForm (Manage Doctors)"]
        AppointmentsForm["AppointmentsForm (Manage Appointments)"]
        PatientPortalForm["PatientPortalForm (Patient Workspace)"]
    end

    subgraph Business & Data Access Layer (Repositories)
        UserRepository["UserRepository"]
        DoctorRepository["DoctorRepository"]
        PatientRepository["PatientRepository"]
        AppointmentRepository["AppointmentRepository"]
    end

    subgraph Data Models (Entities)
        User["User Model"]
        Doctor["Doctor Model"]
        Patient["Patient Model"]
        Appointment["Appointment Model"]
    end

    subgraph Infrastructure
        DatabaseHelper["DatabaseHelper (SQLite Engine Wrapper)"]
        clinic_db[("clinic.db (Local File)")]
    end

    %% Routing
    RoleSelectForm --> LoginForm
    RoleSelectForm --> PatientPortalForm
    LoginForm --> MainForm
    
    %% Repository mapping
    MainForm --> DoctorRepository
    MainForm --> PatientRepository
    MainForm --> AppointmentRepository
    DoctorsForm --> DoctorRepository
    AppointmentsForm --> AppointmentRepository
    PatientPortalForm --> PatientRepository
    PatientPortalForm --> AppointmentRepository

    %% Entities mapping
    DoctorRepository -.-> Doctor
    PatientRepository -.-> Patient
    AppointmentRepository -.-> Appointment
    UserRepository -.-> User

    %% Data connections
    UserRepository --> DatabaseHelper
    DoctorRepository --> DatabaseHelper
    PatientRepository --> DatabaseHelper
    AppointmentRepository --> DatabaseHelper
    DatabaseHelper --> clinic_db
```

### 3.1 Presentation Layer (UI)
*   **RoleSelectForm**: Handles user routing to either the patient portal or the reception console.
*   **LoginForm**: Validates administrative credentials (`admin` / `admin123`).
*   **MainForm**: Displays live statistics cards and provides rapid navigation to sub-modules. Uses custom resize calculation handlers.
*   **DoctorsForm / PatientsForm**: Renders GridViews of records, handles text-search filters, and houses data input textboxes.
*   **AppointmentsForm**: Manages scheduling workflows.

### 3.2 Repositories (Data Access)
*   **UserRepository**: Handles administrative lookup and login verification.
*   **DoctorRepository**: Contains operations to retrieve all doctors, search profiles, create records, update schedules, and delete files.
*   **PatientRepository**: Manages patient lookups, logins, and registrations.
*   **AppointmentRepository**: Manages booking records, retrieves occupied slots for a doctor on a specific date, updates appointment statuses, and calculates live dashboard statistics.

---

## SECTION 4: DATABASE SCHEMA DESIGN

The relational data model is backed by **SQLite**. Data integrity is maintained via primary-to-foreign key mapping.

### 4.1 Users Table (Staff Accounts)
Holds login credentials for receptionists and system administrators.
*   `UserID`: `INTEGER PRIMARY KEY AUTOINCREMENT`
*   `Username`: `TEXT UNIQUE NOT NULL`
*   `Password`: `TEXT NOT NULL`
*   `FullName`: `TEXT`

### 4.2 Doctors Table (Medical Specialists)
Stores profile directories, availability, and billing rates.
*   `DoctorID`: `INTEGER PRIMARY KEY AUTOINCREMENT`
*   `Name`: `TEXT NOT NULL`
*   `Specialization`: `TEXT NOT NULL`
*   `Phone`: `TEXT`
*   `AvailableDays`: `TEXT` (e.g. "Mon, Wed, Fri")
*   `AvailableSlots`: `TEXT` (e.g. "10:00 AM, 11:00 AM")
*   `RoomNumber`: `TEXT`
*   `Fee`: `REAL`

### 4.3 Patients Table (Patient Records)
Maintains profiles and credentials. The unique phone number is used as the login username for patients.
*   `PatientID`: `INTEGER PRIMARY KEY AUTOINCREMENT`
*   `Name`: `TEXT NOT NULL`
*   `Age`: `INTEGER`
*   `Gender`: `TEXT`
*   `Phone`: `TEXT NOT NULL UNIQUE`
*   `Address`: `TEXT`
*   `Password`: `TEXT NOT NULL` (Defaults to phone number upon automatic registration)

### 4.4 Appointments Table (Consultation Logs)
Tracks consultation details, date, time slots, and clinical notes.
*   `AppointmentID`: `INTEGER PRIMARY KEY AUTOINCREMENT`
*   `PatientID`: `INTEGER` (Foreign Key referencing `Patients.PatientID`)
*   `DoctorID`: `INTEGER` (Foreign Key referencing `Doctors.DoctorID`)
*   `AppointmentDate`: `TEXT` (Stored in ISO format: `YYYY-MM-DD`)
*   `AppointmentTime`: `TEXT` (e.g. "10:00 AM")
*   `Status`: `TEXT` (e.g. "Pending", "Confirmed", "Completed", "Cancelled")
*   `Notes`: `TEXT`
*   `BookedBy`: `TEXT` (e.g. "Staff", "Patient")

---

## SECTION 5: PORTABILITY & DEPLOYMENT MANUAL

### 5.1 Why SQLite?
Traditional desktop apps use server-bound database engines (like Microsoft SQL Server, MySQL, or PostgreSQL). This requires installing localized database engines, executing custom SQL backup scripts, and modifying complex connection strings.

By using **SQLite**, the application embeds the SQL engine within the compiler via NuGet (`System.Data.SQLite`). The entire database exists inside a single file (`clinic.db`) in the application's root directory. Deployment is as simple as:
1.  Copying the application folder to any PC.
2.  Double-clicking `ClinicApp.exe`. 
3.  The app handles the rest, building tables and generating demo records automatically.

### 5.2 Environment Setup Guide
1.  **Extract Files**: Place the project folder onto the target machine.
2.  **Open in Visual Studio**: Double-click `ClinicApp.sln`. Visual Studio will automatically restore the `System.Data.SQLite` NuGet package.
3.  **Compile & Run**: Click **Start** (or press `F5`) in Visual Studio.
4.  **CLI Method**: Alternatively, run using the CLI in the project folder:
    ```bash
    dotnet restore ClinicApp\ClinicApp.csproj
    dotnet build ClinicApp\ClinicApp.csproj
    dotnet run --project ClinicApp\ClinicApp.csproj
    ```

### 5.3 Database Auto-Migration Logic
The `DatabaseHelper.InitializeDatabase()` method executes automatically during app launch to construct or upgrade the database:
```csharp
public static void InitializeDatabase()
{
    if (!File.Exists(dbName))
    {
        SQLiteConnection.CreateFile(dbName); // Auto-creates clinic.db file
    }
    using (var conn = GetConnection())
    {
        using (var cmd = new SQLiteCommand(conn))
        {
            // Auto-creates tables if they do not exist
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Doctors (...)";
            cmd.ExecuteNonQuery();

            // Self-Healing migrations: Check and add missing columns dynamically
            try {
                cmd.CommandText = "ALTER TABLE Doctors ADD COLUMN AvailableSlots TEXT";
                cmd.ExecuteNonQuery();
            } catch { }

            // Seeds administrative and doctor data if empty
            cmd.CommandText = "SELECT COUNT(*) FROM Users";
            long count = (long)cmd.ExecuteScalar();
            if (count == 0) {
                cmd.CommandText = "INSERT INTO Users (Username, Password, FullName) VALUES ('admin', 'admin123', ...)";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
```

---

## SECTION 6: VIVA PREPARATION & TECHNICAL Q&A

This section provides answers to questions that teachers commonly ask during project evaluations.

### Q1: What architectural patterns are implemented in your codebase?
*   **Answer**: I used the **3-Tier / Repository Pattern Architecture**. Presentation Forms (`LoginForm`, `MainForm`, etc.) manage the UI. All SQL logic is encapsulated inside dedicated repositories (`UserRepository`, `DoctorRepository`, `PatientRepository`, `AppointmentRepository`). They query the database through a shared helper class (`DatabaseHelper`). This separates UI code from data retrieval code, keeping it highly modular, reusable, and easy to maintain.

### Q2: How did you implement database portability?
*   **Answer**: Instead of using heavy database servers like MS SQL Server or MySQL, which require local installations and complex setup processes, I used **SQLite**. SQLite is serverless and embedded directly into the application. The database is a single local file (`clinic.db`) in the application root. On launch, the system automatically checks for the database file, creates the tables, and populates it with sample data if it's missing, making it 100% plug-and-play.

### Q3: How does your code protect against database connection leaks?
*   **Answer**: I implemented **`using(...)` blocks** on all connections, commands, and reader streams. C# automatically compiles `using` statements into `try...finally` structures. This ensures that the database connection is immediately closed and resources are disposed of, even if a database query fails. This prevents database lockups and connection leaks.

### Q4: How does your system protect against SQL Injection attacks?
*   **Answer**: The codebase strictly uses **SQL Parameterization** instead of raw string concatenation. For example, queries are written as:
    `"SELECT * FROM Users WHERE Username = @u AND Password = @p"`
    By mapping inputs to parameters (`cmd.Parameters.AddWithValue("@u", username)`), the SQLite database engine treats inputs strictly as literal values rather than executable code. This eliminates the risk of SQL Injection.

### Q5: How did you implement appointment scheduling and double-booking prevention?
*   **Answer**: In the database, doctor time slots are saved as comma-separated values. When booking an appointment, the UI queries the `GetBookedSlots()` method in `AppointmentRepository` for the selected doctor and date. It retrieves all active (non-cancelled) booked times. The frontend then compares the doctor's full schedule against these booked slots and disables already occupied times, preventing scheduling conflicts.

### Q6: If the database needs to scale to handle multiple receptionist computers simultaneously, how would you migrate the system?
*   **Answer**: Because I used the Repository Pattern, the migration would be straightforward. I would only need to update the connection string in `DatabaseHelper.cs` to point to a centralized database server (like PostgreSQL or Microsoft SQL Server) and restore the corresponding database provider package. The frontend UI forms would require **zero modifications** because they only interact with the Repository APIs, not direct SQL strings. This demonstrates the power of clean, decoupled code.
