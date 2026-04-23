import React, { useState, useEffect } from "react";

export default function StudentForm({ onSubmit, editData }) {
  const [form, setForm] = useState({
    name: "", email: "", age: "", course: ""
  });

  useEffect(() => {
    if (editData) {
      setForm(editData);
    } else {
      setForm({ name: "", email: "", age: "", course: "" });
    }
  }, [editData]);

  return (
    <form
      onSubmit={(e) => {
        e.preventDefault();
        onSubmit(form);
      }}
    >
        
      <h5 className="mb-3">
        {editData ? "Update Student" : "Add Student"}
      </h5>


      {/* Name */}
      <div className="mb-3">
        <label className="form-label">Name</label>
        <input
          className="form-control"
          placeholder="Enter name"
          value={form.name}
          onChange={(e) =>
            setForm({ ...form, name: e.target.value })
          }
        />
      </div>

      {/* Email */}
      <div className="mb-3">
        <label className="form-label">Email</label>
        <input
          className="form-control"
          placeholder="Enter email"
          value={form.email}
          onChange={(e) =>
            setForm({ ...form, email: e.target.value })
          }
        />
      </div>

      {/* Age */}
      <div className="mb-3">
        <label className="form-label">Age</label>
        <input
          type="number"
          className="form-control"
          placeholder="Enter age"
          value={form.age}
          onChange={(e) =>
            setForm({ ...form, age: e.target.value })
          }
        />
      </div>

      {/* Course */}
      <div className="mb-3">
        <label className="form-label">Course</label>
        <input
          className="form-control"
          placeholder="Enter course"
          value={form.course}
          onChange={(e) =>
            setForm({ ...form, course: e.target.value })
          }
        />
      </div>

      {/* Button */}
      <button className={`btn ${editData ? "btn-warning" : "btn-primary"} w-100`}>
        {editData ? "Update Student" : "Add Student"}
      </button>
    </form>
  );
}