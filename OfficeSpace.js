import React from 'react';

const officeList = [
  {
    name: 'CoWork Hub',
    rent: 55000,
    address: 'Koramangala, Bangalore',
    image: 'https://via.placeholder.com/200?text=CoWork+Hub',
  },
  {
    name: 'Startup Space',
    rent: 75000,
    address: 'Hitech City, Hyderabad',
    image: 'https://via.placeholder.com/200?text=Startup+Space',
  },
  {
    name: 'Enterprise Tower',
    rent: 90000,
    address: 'Cyber City, Gurgaon',
    image: 'https://via.placeholder.com/200?text=Enterprise+Tower',
  },
];

const OfficeSpace = () => {
  return (
    <div style={{ padding: '20px' }}>
      <h1>Office Space Rental Listings</h1>
      {officeList.map((office, index) => (
        <div
          key={index}
          style={{
            border: '1px solid #ccc',
            padding: '10px',
            marginBottom: '20px',
            borderRadius: '8px',
          }}
        >
          <img src={office.image} alt={office.name} style={{ width: '200px' }} />
          <h2>{office.name}</h2>
          <p>
            <strong>Address:</strong> {office.address}
          </p>
          <p>
            <strong>Rent:</strong>{' '}
            <span style={{ color: office.rent > 60000 ? 'green' : 'red' }}>
              ₹{office.rent}
            </span>
          </p>
        </div>
      ))}
    </div>
  );
};

export default OfficeSpace;
