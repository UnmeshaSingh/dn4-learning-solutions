import axios from 'axios';
import GitClient from './GitClient';

jest.mock('axios'); // Mock axios globally

describe('Git Client Tests', () => {
  test('should return repository names for techiesyed', async () => {
    const mockData = [
      { name: 'resume-builder' },
      { name: 'ai-chatbot' },
      { name: 'project-visualizer' },
    ];

    axios.get.mockResolvedValue({ data: mockData });

    const repos = await GitClient.getRepositories('techiesyed');
    expect(repos).toEqual(['resume-builder', 'ai-chatbot', 'project-visualizer']);
    expect(axios.get).toHaveBeenCalledWith('https://api.github.com/users/techiesyed/repos');
  });
});
