import React, { useState } from 'react';

function CurrencyConvertor() {
  const [inr, setInr] = useState('');
  const [euro, setEuro] = useState(null);
  const [rate] = useState(0.011); // 1 INR = 0.011 Euro (example rate)

  const handleSubmit = (e) => {
    e.preventDefault();
    const converted = parseFloat(inr) * rate;
    setEuro(converted.toFixed(2));
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Currency Convertor (INR to EURO)</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="number"
          value={inr}
          placeholder="Enter INR amount"
          onChange={(e) => setInr(e.target.value)}
        />
        <button type="submit">Convert</button>
      </form>
      {euro && <p>€ {euro}</p>}
    </div>
  );
}

export default CurrencyConvertor;
