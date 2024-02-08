import React from 'react';
import DateSelector from './DataSelector';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faChevronLeft, faChevronRight } from '@fortawesome/free-solid-svg-icons';

library.add(faChevronLeft, faChevronRight );


export default {
  title: 'MOLECULES/DateSelector',
  component: DateSelector,
};

const Template = (args) => <DateSelector {...args} />;

export const Default = Template.bind({});