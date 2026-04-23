import React, { useEffect, useState } from "react";
import API from "../api/api";
import StudentForm from "../components/StudentForm";

export default function Students() {
  const [students, setStudents] = useState([]);
  const [edit, setEdit] = useState(null);

  const fetchStudents = async () => {
    const res = await API.get("/student");
    setStudents(res.data);
  };

  useEffect(() => {
    fetchStudents();
  }, []);

  const handleSave = async (data) => {
    if (edit) {
      await API.put(`/student/${edit.id}`, { ...data, id: edit.id });
      setEdit(null);
    } else {
      await API.post("/student", data);
    }
    fetchStudents();
  };

  const handleDelete = async (id) => {
    await API.delete(`/student/${id}`);
    fetchStudents();
  };

  return (
    <div className="container mt-4">

      {/* 🔥 HEADER + LOGOUT */}
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h2>Student Management</h2>

        <button
          className="btn btn-outline-danger"
          onClick={() => {
            localStorage.removeItem("token");
            window.location.href = "/";
          }}
        >
          Logout
        </button>
      </div>

      {/* FORM */}
      <div className="card p-3 mb-4">
        <StudentForm onSubmit={handleSave} editData={edit} />
      </div>

      {/* TABLE */}
      <table className="table table-bordered">
        <thead className="table-dark">
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Age</th>
            <th>Course</th>
            <th>Actions</th>
          </tr>
        </thead>

        <tbody>
          {students.map((s) => (
            <tr key={s.id}>
              <td>{s.name}</td>
              <td>{s.email}</td>
              <td>{s.age}</td>
              <td>{s.course}</td>
              <td>
                <button
                  className="btn btn-warning btn-sm me-2"
                  onClick={() => setEdit(s)}
                >
                  Edit
                </button>

                <button
                  className="btn btn-danger btn-sm"
                  onClick={() => handleDelete(s.id)}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}