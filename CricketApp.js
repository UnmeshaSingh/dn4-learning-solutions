import React from 'react';

function CricketApp() {
  const flag = true; // Change this to false to toggle view

  const players = [
    { name: "Virat Kohli", score: 85 },
    { name: "Rohit Sharma", score: 60 },
    { name: "Hardik Pandya", score: 75 },
    { name: "Shubman Gill", score: 55 },
    { name: "Ravindra Jadeja", score: 90 },
    { name: "Rishabh Pant", score: 45 },
    { name: "KL Rahul", score: 88 },
    { name: "Jasprit Bumrah", score: 35 },
    { name: "Mohammed Shami", score: 25 },
    { name: "Surya Kumar", score: 80 },
    { name: "Axar Patel", score: 65 }
  ];

  const filteredPlayers = players.filter(p => p.score < 70); // Arrow function

  const oddTeam = players.filter((_, index) => index % 2 !== 0);
  const evenTeam = players.filter((_, index) => index % 2 === 0);

  const T20players = ["Virat", "Rohit", "Pandya"];
  const RanjiTrophy = ["Gill", "Rahane", "Pujara"];
  const mergedPlayers = [...T20players, ...RanjiTrophy]; // ES6 Merge

  return (
    <div>
      <h2>🏏 Cricket Player Stats</h2>

      {flag ? (
        <>
          <h3>All Players (with map)</h3>
          {players.map((player, index) => (
            <p key={index}>{player.name} — Score: {player.score}</p>
          ))}

          <h3>Players with Score Below 70 (Arrow Function)</h3>
          {filteredPlayers.map((p, index) => (
            <p key={index}>{p.name} — {p.score}</p>
          ))}
        </>
      ) : (
        <>
          <h3>Even Team (Destructuring)</h3>
          {evenTeam.map(({ name }, index) => (
            <p key={index}>{name}</p>
          ))}

          <h3>Odd Team (Destructuring)</h3>
          {oddTeam.map(({ name }, index) => (
            <p key={index}>{name}</p>
          ))}

          <h3>Merged Players (ES6 Spread)</h3>
          <ul>
            {mergedPlayers.map((p, index) => (
              <li key={index}>{p}</li>
            ))}
          </ul>
        </>
      )}
    </div>
  );
}

export default CricketApp;
