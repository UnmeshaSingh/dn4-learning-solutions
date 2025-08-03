import React from 'react';
import { shallow, mount } from 'enzyme';
import CohortDetails from './CohortDetails';
import { CohortData } from './Cohort';

describe('Cohort Details Component', () => {
  const cohort = CohortData[0];

  test('should create the component', () => {
    const wrapper = shallow(<CohortDetails cohort={cohort} />);
    expect(wrapper.exists()).toBe(true);
  });

  test('should initialize the props', () => {
    const wrapper = mount(<CohortDetails cohort={cohort} />);
    expect(wrapper.props().cohort).toEqual(cohort);
  });

  test('should display cohort code in h3', () => {
    const wrapper = mount(<CohortDetails cohort={cohort} />);
    expect(wrapper.find('h3').text()).toBe(cohort.code);
  });

  test('should match snapshot', () => {
    const wrapper = shallow(<CohortDetails cohort={cohort} />);
    expect(wrapper).toMatchSnapshot();
  });
});
