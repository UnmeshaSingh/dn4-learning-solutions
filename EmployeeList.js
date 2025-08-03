import React from 'react';
import EmployeeCard from './EmployeeCard';

const EmployeeList = () => {
  const employees = [
    { name: 'Alice Johnson', role: 'Frontend Developer' },
    { name: 'Bob Smith', role: 'Backend Developer' },
    { name: 'Charlie Lee', role: 'UI/UX Designer' },
  ];

  return (
    <div>
      <h2>Employee List</h2>
      {employees.map((emp, index) => (
        <EmployeeCard key={index} name={emp.name} role={emp.role} />
      ))}
    </div>
  );
};

export default EmployeeList;
