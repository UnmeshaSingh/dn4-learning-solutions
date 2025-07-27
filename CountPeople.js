import React from 'react';

class CountPeople extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      entryCount: 0,
      exitCount: 0
    };
  }

  updateEntry = () => {
    this.setState((prevState) => ({
      entryCount: prevState.entryCount + 1
    }));
  };

  updateExit = () => {
    this.setState((prevState) => ({
      exitCount: prevState.exitCount + 1
    }));
  };

  render() {
    return (
      <div style={{ textAlign: 'center', padding: '20px' }}>
        <h2>Mall Counter</h2>
        <p><strong>Entries:</strong> {this.state.entryCount}</p>
        <p><strong>Exits:</strong> {this.state.exitCount}</p>
        <button onClick={this.updateEntry} style={{ margin: '10px', padding: '10px' }}>
          Login
        </button>
        <button onClick={this.updateExit} style={{ padding: '10px' }}>
          Exit
        </button>
      </div>
    );
  }
}

export default CountPeople;
