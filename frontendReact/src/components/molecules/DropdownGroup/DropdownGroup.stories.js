import React from 'react';
import DropdownGroup from './DropdownGroup';
import { faChevronDown, faChevronUp } from '@fortawesome/free-solid-svg-icons';

export default {
  title: 'MOLECULES/DropdownGroup',
  component: DropdownGroup,
  argTypes: {
    texts: { control: 'array' },
    dropdowns: { control: 'array' },
    icons: { control: 'array' },
  },
};

const Template = (args) => <DropdownGroup {...args} />;

export const Default = Template.bind({});
Default.args = {
  texts: ['Option A', 'Option B'],
  dropdowns: [
    { options: ['A1', 'A2', 'A3'], onSelect: (option) => console.log(option) },
    { options: ['B1', 'B2', 'B3'], onSelect: (option) => console.log(option) },
  ],
  icons: [faChevronDown, faChevronDown],
};