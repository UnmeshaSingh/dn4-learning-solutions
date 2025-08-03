import React from 'react';
import { CohortData } from './Cohort';
import CohortDetails from './CohortDetails';

function App() {
  return (
    <div className="App">
      <h1>Cohort Dashboard</h1>
      <CohortDetails cohort={CohortData[0]} />
    </div>
  );
}

export default App;
