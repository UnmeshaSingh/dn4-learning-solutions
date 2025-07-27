import React, { Component } from 'react';
import Post from '../Post';

class Posts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      error: null
    };
  }

  componentDidMount() {
    this.loadPosts();
  }

  loadPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then((response) => {
        if (!response.ok) throw new Error("Failed to fetch posts");
        return response.json();
      })
      .then((data) => {
        const postList = data.slice(0, 10).map(p => new Post(p.userId, p.id, p.title, p.body));
        this.setState({ posts: postList });
      })
      .catch((err) => {
        this.setState({ error: err.message });
      });
  }

  componentDidCatch(error, info) {
    alert("An error occurred while rendering posts: " + error);
  }

  render() {
    if (this.state.error) {
      return <div>Error: {this.state.error}</div>;
    }

    return (
      <div>
        <h2>Blog Posts</h2>
        {this.state.posts.map(post => (
          <div key={post.id} style={{ border: '1px solid gray', marginBottom: '15px', padding: '10px', borderRadius: '8px' }}>
            <h3>{post.title}</h3>
            <p>{post.body}</p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;
