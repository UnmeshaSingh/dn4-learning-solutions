import React, { Component } from 'react';

class Getuser extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: null,
      loading: true,
      error: null,
    };
  }

  async componentDidMount() {
    try {
      const response = await fetch('https://api.randomuser.me/');
      const data = await response.json();
      const userData = data.results[0];
      this.setState({
        user: {
          title: userData.name.title,
          firstName: userData.name.first,
          image: userData.picture.large,
        },
        loading: false,
      });
    } catch (err) {
      this.setState({ error: 'Failed to fetch user', loading: false });
    }
  }

  render() {
    const { user, loading, error } = this.state;

    if (loading) return <p>Loading user data...</p>;
    if (error) return <p style={{ color: 'red' }}>{error}</p>;

    return (
      <div style={{ padding: '20px' }}>
        <h2>User Details from RandomUser API</h2>
        <img src={user.image} alt="User" style={{ borderRadius: '50%' }} />
        <p>
          <strong>Title:</strong> {user.title}
        </p>
        <p>
          <strong>First Name:</strong> {user.firstName}
        </p>
      </div>
    );
  }
}

export default Getuser;
