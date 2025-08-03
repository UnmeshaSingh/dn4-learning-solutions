import axios from 'axios';

class GitClient {
  static async getRepositories(username) {
    const url = `https://api.github.com/users/${username}/repos`;
    const response = await axios.get(url);
    return response.data.map((repo) => repo.name);
  }
}

export default GitClient;
