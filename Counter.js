import React, { Component } from 'react';

class Counter extends Component {
  constructor(props) {
    super(props);
    this.state = {
      count: 0,
      message: '',
    };
  }

  increment = () => {
    this.setState((prevState) => ({ count: prevState.count + 1 }));
    this.sayHello();
  };

  decrement = () => {
    this.setState((prevState) => ({ count: prevState.count - 1 }));
  };

  sayHello = () => {
    this.setState({ message: 'Hello! You clicked increment.' });
  };

  sayWelcome = (msg) => {
    alert(`Welcome message: ${msg}`);
  };

  handleClick = (e) => {
    alert('I was clicked');
  };

  render() {
    return (
      <div style={{ padding: '20px' }}>
        <h2>Counter Example</h2>
        <p>Count: {this.state.count}</p>
        <button onClick={this.increment}>Increment</button>
        <button onClick={this.decrement} style={{ marginLeft: '10px' }}>Decrement</button>
        <p>{this.state.message}</p>

        <br /><br />
        <button onClick={() => this.sayWelcome('welcome')}>Say Welcome</button>
        <br /><br />
        <button onClick={this.handleClick}>Synthetic Event Click</button>
      </div>
    );
  }
}

export default Counter;
