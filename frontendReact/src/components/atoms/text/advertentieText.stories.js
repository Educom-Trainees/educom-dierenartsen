import React from 'react';
import advertentieText from './advertentieText';

export default {
  title: 'ATOMS/advertentieText',
  component: advertentieText,
  argTypes: {
    text: { control: 'text' },
  },
};

const Template = (args) => <advertentieText {...args} />;

export const Default = {
  args: {
    text: '+1000 Blije Huisdieren',
  },
};