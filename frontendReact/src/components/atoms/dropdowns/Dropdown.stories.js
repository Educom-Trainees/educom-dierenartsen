import React from 'react';
import Dropdown from './Dropdown';
import { faChevronUp } from '@fortawesome/free-solid-svg-icons';

export default {
    title: 'ATOMS/Dropdown',
    component: Dropdown,
    argTypes: {
        option: { control: 'array' },
        onSelect: { control: 'text' },
    },
};

const Template = (args) => <Dropdown {...args} />;

export const Default = Template.bind({});
Default.args = {
  options: ['Option 1', 'Option 2', 'Option 3'],
  onSelect: (option) => console.log(`Selected option: ${option}`),
  icon: faChevronUp,
};

export const Secondary = Template.bind({});
Secondary.args = {
  options: ['Option 1', 'Option 2', 'Option 3'],
  onSelect: (option) => console.log(`Selected option: ${option}`),
  icon: faChevronUp,
  secondaryVariant: true,
};