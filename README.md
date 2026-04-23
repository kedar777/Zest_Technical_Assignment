# 🎓 Student Management System

A full-stack web application built using **ASP.NET Core Web API** and **React** with JWT Authentication.

---

## 🚀 Features

* 🔐 User Login (JWT Authentication)
* 👨‍🎓 Add Student
* 📋 View All Students
* ✏️ Update Student
* ❌ Delete Student
* 🔒 Protected APIs
* 🧪 Unit Testing (Service Layer)

---

## 🛠 Tech Stack

### 🔹 Backend

* ASP.NET Core Web API
* Entity Framework Core
* MySQL
* JWT Authentication
* xUnit + Moq

### 🔹 Frontend

* React
* Axios
* Bootstrap

---

## 📁 Project Structure

### 🔹 Backend (`WebApplication1`)

```
WebApplication1/
│
├── Controllers/
│   ├── AuthController.cs
│   └── StudentController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── Student.cs
│
├── DTOs/
│   └── LoginDto.cs
│
├── Repositories/
│   ├── Interfaces/
│   │   └── IStudentRepository.cs
│   └── StudentRepository.cs
│
├── Service/
│   └── StudentService.cs
│
├── Middleware/
│   └── ExceptionMiddleware.cs
│
├── Program.cs
└── appsettings.json
```

---

### 🔹 Frontend (`student-ui`)

```
student-ui/
│
├── src/
│   ├── api/
│   │   └── api.js
│   │
│   ├── components/
│   │   ├── Navbar.js
│   │   └── StudentForm.js
│   │
│   ├── pages/
│   │   ├── Login.js
│   │   └── Students.js
│   │
│   ├── App.js
│   └── index.js
│
└── package.json
```

---

## ⚙️ Setup Instructions

### 🔹 Backend Setup

1. Open solution in Visual Studio
2. Configure database in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=StudentDB;user=root;password=yourpassword"
}
```

3. Apply migrations:

```bash
dotnet ef database update
```

4. Run backend:

```bash
dotnet run
```

API runs at:

```
http://localhost:5000
```

---

### 🔹 Frontend Setup

```bash
cd student-ui
npm install
npm start
```

Frontend runs at:

```
http://localhost:3000
```

---

## 🔐 Authentication Flow

1. User logs in via `/api/auth/login`
2. Server returns JWT token
3. Token stored in `localStorage`
4. Axios attaches token:

```
Authorization: Bearer <token>
```

5. Protected APIs validate token

---

## 🔄 API Endpoints

### 🔹 Auth

* `POST /api/auth/login`

### 🔹 Students

* `GET /api/student`
* `POST /api/student`
* `PUT /api/student/{id}`
* `DELETE /api/student/{id}`

---

## 🧪 Testing

Run tests:

```bash
dotnet test WebApplication1.Tests
```

---

## ⚠️ Notes

* Enable CORS in backend
* MySQL must be running
* Do not send `Id` while adding student
* `Id` is auto-incremented

---

## 👨‍💻 Author

Kedar Mane

---

## ⭐ Future Improvements

* Role-based authentication
* Pagination & search
* Better UI (Material UI / Tailwind)
* Deployment (Azure / AWS)

---
