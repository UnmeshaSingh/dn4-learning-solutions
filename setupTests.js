import { configure } from 'enzyme';
import Adapter from 'enzyme-adapter-react-19';

// Polyfill for TextEncoder/TextDecoder
import { TextEncoder, TextDecoder } from 'util';

global.TextEncoder = TextEncoder;
global.TextDecoder = TextDecoder;

configure({ adapter: new Adapter() });
