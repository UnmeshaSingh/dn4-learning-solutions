import React, { useState } from 'react';

const ComplaintRegister = () => {
  const [employeeName, setEmployeeName] = useState('');
  const [complaint, setComplaint] = useState('');
  const [referenceNumber, setReferenceNumber] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (employeeName.trim() === '' || complaint.trim() === '') {
      alert('Please fill in all fields');
      return;
    }

    // Generate random 6-digit reference number
    const refNo = Math.floor(100000 + Math.random() * 900000);
    setReferenceNumber(refNo);

    alert(`Complaint submitted successfully!\nReference No: ${refNo}`);

    // Reset form
    setEmployeeName('');
    setComplaint('');
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Complaint Registration</h2>
      <form onSubmit={handleSubmit}>
        <div style={{ marginBottom: '10px' }}>
          <label>Employee Name:</label><br />
          <input
            type="text"
            value={employeeName}
            onChange={(e) => setEmployeeName(e.target.value)}
            style={{ width: '300px', padding: '8px' }}
          />
        </div>
        <div style={{ marginBottom: '10px' }}>
          <label>Complaint:</label><br />
          <textarea
            value={complaint}
            onChange={(e) => setComplaint(e.target.value)}
            rows="4"
            cols="40"
            style={{ padding: '8px' }}
          />
        </div>
        <button type="submit">Submit Complaint</button>
      </form>

      {referenceNumber && (
        <p style={{ marginTop: '20px', color: 'green' }}>
          Reference Number: {referenceNumber}
        </p>
      )}
    </div>
  );
};

export default ComplaintRegister;
