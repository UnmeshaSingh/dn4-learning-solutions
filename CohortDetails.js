import React from 'react';
import styles from '../CohortDetails.module.css';

function CohortDetails({ name, stream, startDate, endDate, status }) {
  return (
    <div className={styles.box}>
      <h3 className={status.toLowerCase() === "ongoing" ? styles.green : styles.blue}>
        {name} ({status})
      </h3>
      <dl>
        <dt>Stream:</dt>
        <dd>{stream}</dd>
        <dt>Start Date:</dt>
        <dd>{startDate}</dd>
        <dt>End Date:</dt>
        <dd>{endDate}</dd>
      </dl>
    </div>
  );
}

export default CohortDetails;
