import React, { useContext } from 'react';
import ThemeContext from './ThemeContext';

const EmployeeCard = ({ name, role }) => {
  const theme = useContext(ThemeContext);

  const buttonStyle = {
    backgroundColor: theme === 'dark' ? '#333' : '#eee',
    color: theme === 'dark' ? '#fff' : '#000',
    padding: '8px 12px',
    border: 'none',
    borderRadius: '6px',
    cursor: 'pointer',
  };

  return (
    <div
      style={{
        border: '1px solid #ccc',
        padding: '10px',
        marginBottom: '10px',
        borderRadius: '8px',
      }}
    >
      <h3>{name}</h3>
      <p>Role: {role}</p>
      <button style={buttonStyle}>View Profile</button>
    </div>
  );
};

export default EmployeeCard;
